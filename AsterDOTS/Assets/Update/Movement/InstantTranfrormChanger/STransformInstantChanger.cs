// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Unity.Transforms;
using Update.Spawners.Unit.Initializers;

namespace Update.Movement.InstantTransformChanger
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SBulletInitializer))]
    public partial class STransformInstantChanger : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);

            Entities
                .ForEach((Entity entity, TransformAspect aspect, CChangeTransformRequest request) =>
                {
                    aspect.Position = request.Position;
                    aspect.Rotation = request.Rotation;

                    entityCommandBuffer.RemoveComponent<CChangeTransformRequest>(entity);
                })
                .Run();
        }
    }
}
