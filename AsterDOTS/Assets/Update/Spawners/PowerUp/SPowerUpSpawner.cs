// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Random;
using Core.ECS.Tags.AlienShip;
using Core.ECS.Tags.Asteroid;
using Core.Utils;
using Initialization.Configs;
using Initialization.Configs.EventSystem;
using Initialization.Configs.PowerUp;
using Unity.Entities;
using Unity.Transforms;
using Update.Damage;
using Update.Destroy;
using Update.Spawners.Unit;

namespace Update.Spawners.PowerUp
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SDamageApplier))]
    public partial class SPowerUpSpawner : SystemBase
    {
        protected override void OnUpdate()
        {
            CPowerUpSpawnConfig spawnConfig = SystemAPI.GetSingleton<CPowerUpSpawnConfig>();
            
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            CEventSystemConfig eventSystemConfig = SystemAPI.GetSingleton<CEventSystemConfig>();

            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);
            
            Entities
                .WithAny<CAsteroid, CAlienShip>()
                .WithAll<CDeathEvent>()
                .WithNone<COutOfBounds>()
                .ForEach((TransformAspect aspect) =>
                {
                    if (random.ValueRW.Random.NextFloat() > spawnConfig.Rate) { return; }

                    EntityType type = (EntityType)random.ValueRW.Random.NextInt((int)EntityType.InvulnerableShield, (int)EntityType.BulletShootingDelayDecrease + 1);
                    
                    CUnitSpawnRequest request = 
                        new SpawnRequestBuilder(1)
                        .AddUnit(type, aspect.Position)
                        .Build();
            
                    Entity eventEntity = entityCommandBuffer.Instantiate(eventSystemConfig.EventPrefab);
                    entityCommandBuffer.SetComponent(eventEntity, new COneFrame { FramesActive = 1 });
                    entityCommandBuffer.AddComponent(eventEntity, request);
                })
                .Run();
        }
    }
}
