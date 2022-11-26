// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Update.Destroy;

namespace Core.ECS.OneFrame
{
    [UpdateAfter(typeof(SDeath))]
    public partial class SRemoveOneFrameComponents : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<COneFrame>()
                .ForEach((Entity entity, ref COneFrame eventData) =>
                {
                    eventData.FramesActive -= 1;
                    if (eventData.FramesActive == 0)
                    {
                        entityCommandBuffer.DestroyEntity(entity);
                    }
                })
                .Run();
        }
    }
}
