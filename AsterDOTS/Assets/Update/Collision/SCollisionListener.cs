// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Unit;
using Initialization.Configs;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;

namespace Update.Collision
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(PhysicsSystemGroup))]
    public partial class SCollisionListener : SystemBase
    {
        [BurstCompile]
        struct CollisionEventListenerJob : ITriggerEventsJob
        {
            public CollisionMap CollisionPairs;
            public ComponentLookup<CUnit> UnitFilter;
            public EntityCommandBuffer EntityCommandBuffer;

            public void Execute(TriggerEvent triggerEvent)
            {
                int entityAIndex = triggerEvent.EntityA.Index;
                int entityBIndex = triggerEvent.EntityB.Index;

                if (CollisionPairs.TryAddPair(entityAIndex, entityBIndex))
                {
                    EntityType entityTypeA = GetEntityType(triggerEvent.EntityA);
                    EntityType entityTypeB = GetEntityType(triggerEvent.EntityB);
                    EntityCommandBuffer.AddComponent(triggerEvent.EntityA, new CCollision
                    {
                        OwnerEntityType = entityTypeA,
                        OtherEntityType = entityTypeB
                    });
                    EntityCommandBuffer.AddComponent(triggerEvent.EntityB, new CCollision
                    {
                        OwnerEntityType = entityTypeB,
                        OtherEntityType = entityTypeA
                    });
                }
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

        protected override void OnUpdate()
        {
            ComponentLookup<CUnit> unitFilter = GetComponentLookup<CUnit>();

            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);

            Dependency = new CollisionEventListenerJob
            {
                CollisionPairs = new CollisionMap(EntityManager.EntityCapacity),
                UnitFilter = unitFilter,
                EntityCommandBuffer = entityCommandBuffer
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), Dependency);
        }
    }
}
