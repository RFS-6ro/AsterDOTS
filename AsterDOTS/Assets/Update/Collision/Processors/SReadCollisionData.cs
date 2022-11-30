// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Unity.Entities;

namespace Update.Collision.Processors
{
    //NOTE: This System is a template for other collision processors
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(CollisionHandlingGroup))]
    [UpdateAfter(typeof(SCollisionListener))]
    public partial class SReadCollisionData : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<COneFrame>()
                .ForEach((CCollisionData data) =>
                {
                })
                .Run();
        }
    }
}