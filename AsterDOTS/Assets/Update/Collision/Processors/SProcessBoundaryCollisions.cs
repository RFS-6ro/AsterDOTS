// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.Utils;
using Unity.Entities;
using Update.Destroy;

namespace Update.Collision.Processors
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(CollisionHandlingGroup))]
    [UpdateAfter(typeof(SReadCollisionData))]
    public partial class SProcessBoundaryCollisions : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<COneFrame>()
                .ForEach((ref CCollisionData data) =>
                {
                    if (data.Processed) { return; }

                    if (!data.IsBoundaryCollision()) { return; }
                    
                    //TODO: teleport entity to opposite bounds
                    // entityCommandBuffer.AddComponent(entity, boundaryConfig.GetSeamlessPosition(aspect));
                    // entityCommandBuffer.AddComponent(entity, new CCollisionDelay
                    // {
                    //     CollisionTime = SystemAPI.Time.ElapsedTime
                    // });
                    
                    entityCommandBuffer.AddComponent(data.GetNonBoundary(), new CDeathEvent());
                    entityCommandBuffer.AddComponent(data.GetNonBoundary(), new COutOfBounds());

                    data.Processed = true;
                })
                .Run();
        }
    }
}
