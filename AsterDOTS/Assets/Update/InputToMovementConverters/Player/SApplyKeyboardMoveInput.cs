// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.InputListener;
using Core.ECS.Tags.Player;
using Core.ECS.Tags.Ship;
using Unity.Entities;
using Unity.Transforms;
using Update.Input;
using Update.Movement.Position;
using Update.Movement.Rotation;

namespace Update.InputToMovementConverters.Player
{
    [UpdateAfter(typeof(SReadKeyboardInput))]
    public partial class SApplyKeyboardMoveInput : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CPlayer>()
                .WithAll<CShip>()
                .WithAll<CInputListener>()
                .ForEach((TransformAspect aspect, CFrameInputData frameInputData, ref CMoveDirection moveDirection, ref CRotation rotation) =>
                {
                    if (frameInputData.Acceleration)
                    {
                        moveDirection.Vector = aspect.Forward;
                    }

                    rotation.Angle = frameInputData.Rotation;
                })
                .Run();
        }
    }
}
