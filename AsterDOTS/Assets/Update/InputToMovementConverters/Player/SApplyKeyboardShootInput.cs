// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.InputListener;
using Core.ECS.Tags.Weapon;
using Unity.Entities;
using Unity.Transforms;
using Update.Input;
using Update.Spawners.Bullets;

namespace Update.InputToMovementConverters.Player
{
    [UpdateAfter(typeof(SApplyKeyboardMoveInput))]
    public partial class SApplyKeyboardShootInput : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CWeapon>()
                .WithAll<CInputListener>()
                .ForEach((CFrameInputData frameInputData, ref CBulletShotRequest request) =>
                {
                    if (frameInputData.IsShotRequested && !request.IsActive && !request.InProgress)
                    {
                        request.IsActive = true;
                    }
                })
                .Run();
        }
    }
}
