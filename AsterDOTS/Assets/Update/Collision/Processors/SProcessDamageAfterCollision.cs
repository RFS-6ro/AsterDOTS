// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Tags.Damageable;
using Core.ECS.Tags.Unit;
using Core.Utils;
using Unity.Entities;
using Update.Damage;

namespace Update.Collision.Processors
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(CollisionHandlingGroup))]
    [UpdateAfter(typeof(SProcessPowerUpsPickUp))]
    public partial class SProcessDamageAfterCollision : SystemBase
    {
        protected override void OnUpdate()
        {
            // ComponentLookup<CUnit> unitFilter = GetComponentLookup<CUnit>();
            ComponentLookup<CDamageable> damageableFilter = GetComponentLookup<CDamageable>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<COneFrame>()
                .ForEach((ref CCollisionData data) =>
                {
                    if (data.Processed) { return; }
                    
                    if (data.IsBoundaryCollision()) { return; }

                    if (damageableFilter.HasComponent(data.A.Entity))
                    {
                        entityCommandBuffer.AddComponent(data.A.Entity, new CDamage
                        {
                            Amount = 1
                        });
                    }
                    
                    if (damageableFilter.HasComponent(data.B.Entity))
                    {
                        entityCommandBuffer.AddComponent(data.B.Entity, new CDamage
                        {
                            Amount = 1
                        });
                    }
                    
                    // Debug.Log("SReadCollisionData");
                    // entityCommandBuffer.AddComponent(data.A.Entity, new ());
                    // Debug.Log("SReadCollisionData 2");
                    // entityCommandBuffer.AddComponent(data.B.Entity, new COneFrame());
                    // Debug.Log("SReadCollisionData 3");

                    // if (data.IsBoundaryCollision())
                    // {
                    //     Debug.Log("Столкнулись с границами");
                    // }

                    data.Processed = true;
                })
                .Run();
        }
    }
}