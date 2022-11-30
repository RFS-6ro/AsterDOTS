// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Weapon;
using Initialization.Configs;
using Initialization.Configs.BulletMove;
using Unity.Entities;
using Update.Spawners.Unit;
using Update.Spawners.Unit.Initializers;

namespace Update.PowerUps.Shooting.BulletSpeedChange
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SUnitSpawner))]
    [UpdateBefore(typeof(SBulletInitializer))]
    public partial class SBulletSpeedChangeApply : SystemBase
    {
        protected override void OnUpdate()
        {
            RefRW<CBulletMoveConfig> bulletMoveConfig = SystemAPI.GetSingletonRW<CBulletMoveConfig>();

            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<CWeapon>()
                .WithAll<CBulletSpeedChange>()
                .ForEach((Entity entity, CBulletSpeedChange change) =>
                {
                    if (change.TargetBullets == EntityType.EnemyBullet)
                    {
                        bulletMoveConfig.ValueRW.EnemyBulletSpeed *= change.Multiplier;
                    }
                    else
                    {
                        bulletMoveConfig.ValueRW.PlayerBulletSpeed *= change.Multiplier;
                    }
                    entityCommandBuffer.RemoveComponent<CBulletSpeedChange>(entity);
                })
                .Run();
        }
    }
}
