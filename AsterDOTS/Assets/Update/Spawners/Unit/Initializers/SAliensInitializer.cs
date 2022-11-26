// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Random;
using Core.ECS.Tags.AlienShip;
using Core.ECS.Tags.Initialize;
using Core.Utils;
using Initialization.Configs.AlienShipMove;
using Initialization.Configs.PlayerMovement;
using Unity.Entities;
using Update.Movement.Rotation;

namespace Update.Spawners.Unit.Initializers
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SAsteroidInitializer))]
    public partial class SAliensInitializer : SystemBase
    {
        protected override void OnUpdate()
        {
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            
            CAlienShipMoveConfig entityMoveConfig = SystemAPI.GetSingleton<CAlienShipMoveConfig>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);

            Entities
                .WithAll<CAlienShip>()
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
                        Angle = random.ValueRW.Random.NextFloat(-0.2f, 0.2f)
                    });
                
                    entityCommandBuffer.RemoveComponent<CNeedInitialize>(entity);
                    entityCommandBuffer.AddComponent(entity, new CInitialized());
                })
                .Run();
        }
    }
}
