// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Damageable;
using Unity.Entities;
using Update.Movement.Rotation;

namespace Update.Destroy
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SEntityRotateByAngle))]
    public partial class SDeath : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<CDamageable>()
                .WithAll<CDeathEvent>()
                .ForEach((Entity entity) =>
                {
                    entityCommandBuffer.DestroyEntity(entity);
                })
                .Run();
        }
    }
}
