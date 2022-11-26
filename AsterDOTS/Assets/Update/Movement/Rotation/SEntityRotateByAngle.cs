// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Movable;
using Initialization.Configs.PlayerMovement;
using Unity.Entities;
using UnityEngine;
using Update.Movement.Position;

namespace Update.Movement.Rotation
{
    [UpdateAfter(typeof(SEntityMoveInDirection))]
    public partial class SEntityRotateByAngle : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CMovable>()
                .ForEach((CEntitySpeed speed, CRotation rotationValue, ref Unity.Transforms.Rotation rotation) =>
                {
                    rotation.Value *= Quaternion.Euler(0f, rotationValue.Angle * speed.RotationMultiplier, 0f);
                })
                .Run();
        }
    }
}