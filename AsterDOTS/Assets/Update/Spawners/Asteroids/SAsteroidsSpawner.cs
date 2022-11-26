// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Random;
using Core.ECS.Tags.Asteroid;
using Core.Utils;
using Initialization.Configs;
using Initialization.Configs.AsteroidsSpawnRate;
using Initialization.Configs.Boundary;
using Initialization.Configs.EventSystem;
using Initialization.WorldCreation;
using Unity.Entities;
using Unity.Mathematics;
using Update.Spawners.Unit;

namespace Update.Spawners.Asteroids
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SInitialPlayerSpawner))]
    public partial class SAsteroidsSpawner : SystemBase
    {
        private double _lastSpawnTime;

        protected override void OnUpdate()
        {
            CAsteroidsSpawnRateConfig spawnRateConfig = SystemAPI.GetSingleton<CAsteroidsSpawnRateConfig>();
            CBoundaryConfig boundaryConfig = SystemAPI.GetSingleton<CBoundaryConfig>();
            EntityQuery asteroidsQuery = EntityManager.CreateEntityQuery(typeof(CAsteroid));

            int entities = asteroidsQuery.CalculateEntityCount();
            int maxEntities = spawnRateConfig.BigAsteroidsSceneBuffer
                              + spawnRateConfig.MediumAsteroidsSceneBuffer
                              + spawnRateConfig.SmallAsteroidsSceneBuffer;
            
            if (entities != 0 
                || entities > maxEntities
                || (SystemAPI.Time.ElapsedTime - _lastSpawnTime < spawnRateConfig.Delay && !_lastSpawnTime.IsZero())) { return; }

            _lastSpawnTime = SystemAPI.Time.ElapsedTime;
            
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            CEventSystemConfig eventSystemConfig = SystemAPI.GetSingleton<CEventSystemConfig>();

            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);
            
            SpawnRequestBuilder builder = new SpawnRequestBuilder(maxEntities);

            for (EntityType type = EntityType.AsteroidSmall; type <= EntityType.AsteroidBig; type++)
            {
                for (int i = 0; i < spawnRateConfig.GetAsteroidSceneBufferCount(type); i++)
                {
                    (float3 position, float3 forward) transform = boundaryConfig.GetRandomBoundaryTransform(random);

                    builder.AddUnit(type, transform.position, transform.forward);
                }
            }

            CUnitSpawnRequest request = builder.Build();
            
            Entity eventEntity = entityCommandBuffer.Instantiate(eventSystemConfig.EventPrefab);
            entityCommandBuffer.SetComponent(eventEntity, new COneFrame { FramesActive = 1 });
            entityCommandBuffer.AddComponent(eventEntity, request);
        }
    }
}
