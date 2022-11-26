// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Random;
using Core.Utils;
using Initialization.Configs;
using Initialization.Configs.AsteroidsSpawnRate;
using Initialization.Configs.Boundary;
using Initialization.Configs.EventSystem;
using Unity.Entities;
using Unity.Transforms;
using Update.Damage;
using Update.Spawners.Unit;

namespace Update.Collision
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(SCollisionListener))]
    public partial class SCollisionHandler : SystemBase
    {
        protected override void OnUpdate()
        {
            CBoundaryConfig boundaryConfig = SystemAPI.GetSingleton<CBoundaryConfig>();
            CAsteroidsSpawnRateConfig spawnRateConfig = SystemAPI.GetSingleton<CAsteroidsSpawnRateConfig>();
            CEventSystemConfig eventSystemConfig = SystemAPI.GetSingleton<CEventSystemConfig>();
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<CCollision>()
                .WithNone<CCollisionDelay>()
                .ForEach((TransformAspect aspect, Entity entity, CCollision collision) =>
                {
                    if (collision.OtherEntityType == EntityType.Boundary)
                    {
                        //teleport entity to opposite bounds
                        entityCommandBuffer.AddComponent(entity, boundaryConfig.GetSeamlessPosition(aspect));
                        entityCommandBuffer.AddComponent(entity, new CCollisionDelay
                        {
                            CollisionTime = SystemAPI.Time.ElapsedTime
                        });
                        return;
                    }

                    int fragments = -1;
                    EntityType fragmentsType = EntityType.None;
                    
                    if (collision.OwnerEntityType == EntityType.AsteroidBig)
                    {
                        fragments = spawnRateConfig.MediumAsteroidsAfterDestroy;
                        fragmentsType = EntityType.AsteroidMedium;
                    }

                    if (collision.OwnerEntityType == EntityType.AsteroidMedium)
                    {
                        fragments = spawnRateConfig.SmallAsteroidsAfterDestroy;
                        fragmentsType = EntityType.AsteroidSmall;
                    }

                    if (fragments != -1 && fragmentsType != EntityType.None)
                    {
                        SpawnRequestBuilder builder = new SpawnRequestBuilder(fragments);
                        for (int i = 0; i < fragments; i++)
                        {
                            builder.AddUnit(EntityType.AsteroidMedium, aspect.Position,
                                aspect.Forward + random.ValueRW.Random.NextFloat3());
                        }
                        
                        CUnitSpawnRequest request = builder.Build();
            
                        Entity eventEntity = entityCommandBuffer.Instantiate(eventSystemConfig.EventPrefab);
                    
                        entityCommandBuffer.SetComponent(eventEntity, new COneFrame { FramesActive = 1 });
                        entityCommandBuffer.AddComponent(eventEntity, request);
                    }
                    
                    entityCommandBuffer.RemoveComponent<CCollision>(entity);
                    
                    if (collision.OwnerEntityType == EntityType.Boundary
                        || collision.OwnerEntityType == EntityType.Weapon) { return; }
                    
                    entityCommandBuffer.AddComponent(entity, new CCollisionDelay
                    {
                        CollisionTime = SystemAPI.Time.ElapsedTime
                    });

                    entityCommandBuffer.AddComponent(entity, new CDamage
                    {
                        Amount = 1
                    });
                    
                })
                .Run();
        }
    }
}
