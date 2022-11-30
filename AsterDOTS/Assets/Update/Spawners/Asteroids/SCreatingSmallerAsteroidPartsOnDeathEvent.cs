// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Random;
using Core.ECS.Tags.Asteroid;
using Core.ECS.Tags.Unit;
using Core.Utils;
using Initialization.Configs;
using Initialization.Configs.AsteroidsSpawnRate;
using Initialization.Configs.EventSystem;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Update.Destroy;
using Update.Movement.Rotation;
using Update.Spawners.Unit;

namespace Update.Spawners.Asteroids
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SEntityRotateByAngle))]
    [UpdateBefore(typeof(SDeath))]
    public partial class SCreatingSmallerAsteroidPartsOnDeathEvent : SystemBase
    {
        protected override void OnUpdate()
        {
            CAsteroidsSpawnRateConfig spawnRateConfig = SystemAPI.GetSingleton<CAsteroidsSpawnRateConfig>();
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            CEventSystemConfig eventSystemConfig = SystemAPI.GetSingleton<CEventSystemConfig>();
            
            Entities
                .WithAll<CAsteroid>()
                .WithNone<COutOfBounds>()
                .WithAll<CDeathEvent>()
                .ForEach((Entity entity, CUnit unit, TransformAspect aspect) =>
                {
                    (EntityType type, int count) result = unit.EntityType switch
                    {
                        EntityType.AsteroidBig => (EntityType.AsteroidMedium, spawnRateConfig.MediumAsteroidsAfterDestroy),
                        EntityType.AsteroidMedium => (EntityType.AsteroidSmall, spawnRateConfig.SmallAsteroidsAfterDestroy),
                        _ => (EntityType.None, -1)
                    };

                    if (result.count <= 0) { return; }
                    
                    entityCommandBuffer.AddComponent(entity, new COutOfBounds());

                    SpawnRequestBuilder builder = new SpawnRequestBuilder(result.count);

                    for (int i = 0; i < result.count; i++)
                    {
                        builder.AddUnit
                        (
                            result.type, 
                            aspect.Position, 
                            new float3(0, 0, random.ValueRW.Random.NextInt(-1, 2))
                        );
                    }
                    
                    var request = builder.Build();

                    Entity summonEvent = entityCommandBuffer.Instantiate(eventSystemConfig.EventPrefab);
                    entityCommandBuffer.SetComponent(summonEvent, new COneFrame { FramesActive = 1 });
                    entityCommandBuffer.AddComponent(summonEvent, request);
                })
                .Run();
        }
    }
}
