// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Tags.Unit;
using Initialization.Configs;
using Initialization.Configs.EventSystem;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Update.Destroy;

namespace Update.Collision
{
    [UpdateInGroup(typeof(CollisionHandlingGroup))]
    [BurstCompile]
    public partial class SCollisionListener : SystemBase
    {
        [BurstCompile]
        struct CollisionEventListenerJob : ITriggerEventsJob
        {
            public CollisionMap CollisionPairs;
            public ComponentLookup<CUnit> UnitFilter;
            public ComponentLookup<CDeathEvent> DeathEventFilter;
            public EntityCommandBuffer EntityCommandBuffer;
            public CEventSystemConfig EventSystemConfig;

            public void Execute(TriggerEvent triggerEvent)
            {
                if (!IsCollisionValid(triggerEvent)) { return; }

                Entity eventEntity = EntityCommandBuffer.Instantiate(EventSystemConfig.EventPrefab);
                EntityCommandBuffer.SetComponent(eventEntity, new COneFrame {FramesActive = 1});
                EntityCommandBuffer.AddComponent(eventEntity, new CCollisionData
                {
                    A = new EntityData
                    {
                        Entity = triggerEvent.EntityA,
                        Type = GetEntityType(triggerEvent.EntityA)
                    },
                    B = new EntityData
                    {
                        Entity = triggerEvent.EntityB,
                        Type = GetEntityType(triggerEvent.EntityB)
                    }
                });
            }

            private bool IsCollisionValid(TriggerEvent triggerEvent)
            {
                int entityAIndex = triggerEvent.EntityA.Index;
                int entityBIndex = triggerEvent.EntityB.Index;

                if (!CollisionPairs.TryAddPair(entityAIndex, entityBIndex)) { return false; }

                EntityType entityTypeA = GetEntityType(triggerEvent.EntityA);
                EntityType entityTypeB = GetEntityType(triggerEvent.EntityB);
                
                if (DeathEventFilter.HasComponent(triggerEvent.EntityA) 
                    || DeathEventFilter.HasComponent(triggerEvent.EntityB)) { return false; }
                
                if (entityTypeA == EntityType.None 
                    || entityTypeB == EntityType.None) { return false; }

                return true;
            }
            
            private EntityType GetEntityType(Entity entity)
            {
                if (UnitFilter.TryGetComponent(entity, out CUnit unitData))
                {
                    return unitData.EntityType;
                }
                
                return EntityType.None;
            }
        }

        [BurstCompile]
        protected override void OnUpdate()
        {
            ComponentLookup<CUnit> unitFilter = GetComponentLookup<CUnit>();
            ComponentLookup<CDeathEvent> deathEventFilter = GetComponentLookup<CDeathEvent>();
            CEventSystemConfig eventSystemConfig = SystemAPI.GetSingleton<CEventSystemConfig>();

            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);

            Dependency = new CollisionEventListenerJob
            {
                CollisionPairs = new CollisionMap(EntityManager.EntityCapacity),
                UnitFilter = unitFilter,
                DeathEventFilter = deathEventFilter,
                EntityCommandBuffer = entityCommandBuffer,
                EventSystemConfig = eventSystemConfig
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), Dependency);
        }
    }
}
