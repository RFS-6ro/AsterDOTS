// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs.Collision;
using Unity.Entities;

namespace Update.Collision
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateAfter(typeof(SCollisionHandler))]
    public partial class SCollisionDelayResolver : SystemBase
    {
        protected override void OnUpdate()
        {
            CCollisionConfig config = SystemAPI.GetSingleton<CCollisionConfig>();

            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<CCollision>()
                .WithAll<CCollisionDelay>()
                .ForEach((Entity entity, CCollisionDelay delay) =>
                {
                    if (SystemAPI.Time.ElapsedTime - delay.CollisionTime > config.Delay)
                    {
                        entityCommandBuffer.RemoveComponent<CCollisionDelay>(entity);
                    }
                })
                .Run();
        }
    }
}