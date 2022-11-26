// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Damageable;
using Unity.Entities;
using Update.Collision;
using Update.Destroy;
using Update.Health;

namespace Update.Damage
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(SCollisionListener))]
    public partial class SDamageApplier : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            Entities
                .WithAll<CDamageable>()
                .ForEach((Entity entity, CDamage damage, ref CHealth health) =>
                {
                    health.Amount -= damage.Amount;
            
                    if (health.Amount <= 0)
                    {
                        health.Amount = 0;
                        entityCommandBuffer.AddComponent(entity, new CDeathEvent());
                    }  
                })
                .Run();
        }
    }
}
