// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.InputListener;
using Initialization.Configs.Input;
using Unity.Entities;
using Update.Spawners.Unit.Initializers;

namespace Update.Input
{
    [UpdateAfter(typeof(SAliensInitializer))]
    public partial class SReadKeyboardInput : SystemBase
    {
        protected override void OnUpdate()
        {
            CInputConfig cInputConfig = SystemAPI.GetSingleton<CInputConfig>();
            Entities
                .WithAll<CInputListener>()
                .ForEach((ref CFrameInputData frameInputData) =>
                {
                    frameInputData.Acceleration = UnityEngine.Input.GetKey(cInputConfig.AccelerationKey);

                    frameInputData.IsShotRequested = UnityEngine.Input.GetKey(cInputConfig.ShootKey);

                    float rotation = 0;
                    rotation += UnityEngine.Input.GetKey(cInputConfig.TurnLeftKey) ? -1f : 0f;
                    rotation += UnityEngine.Input.GetKey(cInputConfig.TurnRightKey) ? 1f : 0f;
                    frameInputData.Rotation = rotation;
                })
                .Run();
        }
    }
}
