// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Weapon;
using Unity.Entities;
using Update.InputToMovementConverters.Alien;
using Update.PowerUps.Shooting.BulletBulletShootingDelayChange;
using Update.Spawners.Bullets;
using Update.Weapons.Stats;

namespace Update.Weapons.Delay
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SBulletShootingDelayChange))]
    public partial class SUpdateBulletDelay : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<CWeapon>()
                .ForEach((Entity entity, CWeaponStats stats, CBulletShotDelay delay, ref CBulletShotRequest request) =>
                {
                    if (SystemAPI.Time.ElapsedTime - delay.LastShotTime >= stats.ShotDelay)
                    {
                        request.InProgress = false;
                        request.IsActive = false;
                        entityCommandBuffer.RemoveComponent<CBulletShotDelay>(entity);
                    }
                })
                .Run();
        }
    }
}
