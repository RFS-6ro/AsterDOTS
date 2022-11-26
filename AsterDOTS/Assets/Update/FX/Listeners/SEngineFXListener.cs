// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Ship;
using Core.Utils;
using Unity.Entities;
using Update.FX.Containers;
using Update.Input;
using Update.Movement.Acceleration;
using Update.Movement.Position;
using Update.Movement.Rotation;

namespace Update.FX.Listeners
{
    [UpdateAfter(typeof(SEntityMoveInDirection))]
    [UpdateAfter(typeof(SEngineAcceleration))]
    [UpdateAfter(typeof(SEntityRotateByAngle))]
    public partial class SEngineFXListener : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CShip>()
                .ForEach((CVFXContainer vfx, CSFXContainer sfx, CFrameInputData frameInputData) =>
                {
                    if (frameInputData.Acceleration)
                    {
                        //Send Move FX Events
                    }

                    if (!frameInputData.Rotation.IsZero())
                    {
                        //Send Rotation FX Events
                    }
                })
                .Run();
        }
    }
}
