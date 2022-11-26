// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Movable;
using Initialization.Configs.PlayerMovement;
using Unity.Entities;
using Unity.Transforms;
using Update.Movement.InstantTransformChanger;

namespace Update.Movement.Position
{
    [UpdateAfter(typeof(STransformInstantChanger))]
    public partial class SEntityMoveInDirection : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CMovable>()
                .ForEach((CEntitySpeed speed, CMoveDirection direction, ref Translation translation)  =>
                {
                    translation.Value += SystemAPI.Time.DeltaTime * direction.Vector * speed.SpeedMultiplier;
                })
                .Run();
        }
    }
}
