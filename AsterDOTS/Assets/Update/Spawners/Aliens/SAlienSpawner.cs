// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Random;
using Core.ECS.Tags.AlienShip;
using Core.Utils;
using Initialization.Configs;
using Initialization.Configs.AlienShipSpawnRate;
using Initialization.Configs.Boundary;
using Initialization.Configs.EventSystem;
using Unity.Entities;
using Unity.Mathematics;
using Update.Spawners.Asteroids;
using Update.Spawners.Unit;

namespace Update.Spawners.Aliens
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SAsteroidsSpawner))]
    public partial class SAlienSpawner : SystemBase
    {
        private double _lastSpawnTime;
        
        protected override void OnUpdate()
        {
            CAlienShipSpawnRateConfig spawnRateConfig = SystemAPI.GetSingleton<CAlienShipSpawnRateConfig>();
            CBoundaryConfig boundaryConfig = SystemAPI.GetSingleton<CBoundaryConfig>();
            EntityQuery alienShipQuery = EntityManager.CreateEntityQuery(typeof(CAlienShip));

            int entities = alienShipQuery.CalculateEntityCount();
            int maxEntities = spawnRateConfig.BigAlienShipSceneBuffer
                              + spawnRateConfig.SmallAlienShipSceneBuffer;
            
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

            for (EntityType type = EntityType.AlienShipSmall; type <= EntityType.AlienShipBig; type++)
            {
                for (int i = 0; i < spawnRateConfig.GetAlienShipSceneBufferCount(type); i++)
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
