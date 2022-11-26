// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Random;
using Core.ECS.Tags.Asteroid;
using Core.ECS.Tags.Initialize;
using Core.Utils;
using Initialization.Configs.AsteroidsMove;
using Initialization.Configs.PlayerMovement;
using Unity.Entities;
using Update.Movement.Rotation;

namespace Update.Spawners.Unit.Initializers
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SPlayerInitializer))]
    public partial class SAsteroidInitializer : SystemBase
    {
        protected override void OnUpdate()
        {
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();

            CAsteroidsMoveConfig entityMoveConfig = SystemAPI.GetSingleton<CAsteroidsMoveConfig>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);

            Entities
                .WithAll<CAsteroid>()
                .WithAll<CNeedInitialize>()
                .ForEach((Entity entity, CUnitInitializationData data) =>
                {

                    entityCommandBuffer.AddComponent(entity, new CEntitySpeed
                    {
                        SpeedMultiplier = entityMoveConfig.GetEntitySpeed(data.UnitType),
                        RotationMultiplier = entityMoveConfig.GetEntityRotationSpeed(data.UnitType)
                    });
                
                    entityCommandBuffer.AddComponent(entity, new CRotation
                    {
                        Angle = random.ValueRW.Random.NextFloat(-1, 1)
                    });

                    entityCommandBuffer.RemoveComponent<CNeedInitialize>(entity);
                    entityCommandBuffer.AddComponent(entity, new CInitialized());
                })
                .Run();
        }
    }
}
