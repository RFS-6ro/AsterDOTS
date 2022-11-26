// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Bullet;
using Core.ECS.Tags.Initialize;
using Initialization.Configs.BulletMove;
using Initialization.Configs.PlayerMovement;
using Unity.Entities;

namespace Update.Spawners.Unit.Initializers
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SUnitSpawner))]
    public partial class SBulletInitializer : SystemBase
    {
        protected override void OnUpdate()
        {
            CBulletMoveConfig entityMoveConfig = SystemAPI.GetSingleton<CBulletMoveConfig>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<CBullet>()
                .WithAll<CNeedInitialize>()
                .ForEach((Entity entity, CUnitInitializationData data) =>
                {
                    entityCommandBuffer.AddComponent(entity, new CEntitySpeed
                    {
                        SpeedMultiplier = entityMoveConfig.BulletSpeed
                    });

                    entityCommandBuffer.RemoveComponent<CNeedInitialize>(entity);
                    entityCommandBuffer.AddComponent(entity, new CInitialized());
                })
                .Run();
        }
    }
}
