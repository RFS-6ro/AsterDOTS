// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Tags.Unit;
using Core.Utils;
using Initialization.Configs;
using Unity.Entities;
using UnityEngine;
using Update.Destroy;
using Update.PowerUps.InvulnerableShield;
using Update.PowerUps.Shooting.BulletBulletShootingDelayChange;
using Update.PowerUps.Shooting.BulletSpeedChange;
using Update.Weapons;

namespace Update.Collision.Processors
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(CollisionHandlingGroup))]
    [UpdateAfter(typeof(SProcessBoundaryCollisions))]
    public partial class SProcessPowerUpsPickUp : SystemBase
    {
        protected override void OnUpdate()
        {
            ComponentLookup<CUnit> unitFilter = GetComponentLookup<CUnit>();
            ComponentLookup<CWeaponLink> weaponLinkFilter = GetComponentLookup<CWeaponLink>();
            
            ComponentLookup<CBulletSpeedChange> bulletCountChangeFilter = GetComponentLookup<CBulletSpeedChange>();
            ComponentLookup<CBulletShootingDelayChange> bulletShootDelayChangeFilter = GetComponentLookup<CBulletShootingDelayChange>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<COneFrame>()
                .ForEach((ref CCollisionData data) =>
                {
                    if (data.Processed) { return; }
                    
                    if (data.IsBoundaryCollision()) { return; }
                    
                    if (!unitFilter.TryGetPowerUpCollision(data, out EntityData picker, out EntityData powerUp)) { return; }
                 
                    entityCommandBuffer.AddComponent(powerUp.Entity, new CDeathEvent());

                    switch (powerUp.Type)
                    {
                        case EntityType.InvulnerableShield:
                            entityCommandBuffer.AddComponent(picker.Entity, new CInvulnerableShield());
                            break;
                        case EntityType.BulletSpeedIncrease:
                            if (weaponLinkFilter.TryGetComponent(picker.Entity, out CWeaponLink link1))
                            {
                                if (bulletCountChangeFilter.TryGetComponent(powerUp.Entity, out CBulletSpeedChange changer1))
                                {
                                    entityCommandBuffer.AddComponent(link1.Weapon, changer1);
                                }
                                else
                                {
                                    entityCommandBuffer.AddComponent(link1.Weapon, new CBulletSpeedChange
                                    {
                                        TargetBullets = picker.Type == EntityType.PlayerShip 
                                            ? EntityType.PlayerBullet 
                                            : EntityType.EnemyBullet,
                                        Multiplier = 2
                                    });
                                }
                            }
                            break;
                        case EntityType.BulletShootingDelayDecrease:
                            if (weaponLinkFilter.TryGetComponent(picker.Entity, out CWeaponLink link2))
                            {
                                if (bulletShootDelayChangeFilter.TryGetComponent(powerUp.Entity, out CBulletShootingDelayChange changer2))
                                {
                                    entityCommandBuffer.AddComponent(link2.Weapon, changer2);
                                }
                                else
                                {
                                    entityCommandBuffer.AddComponent(link2.Weapon, new CBulletShootingDelayChange
                                    {
                                        Multiplier = 0.5f
                                    });
                                }
                            }
                            break;
                    }

                    data.Processed = true;
                })
                .Run();
        }
    }
}