// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Movable;
using Core.ECS.Tags.Ship;
using Initialization.Configs.AccelerationConfig;
using Unity.Entities;
using Update.Movement.Position;

namespace Update.Movement.Acceleration
{
    [UpdateAfter(typeof(SEntityMoveInDirection))]
    public partial class SEngineAcceleration : SystemBase
    {
        protected override void OnUpdate()
        {
            CEngineAccelerationConfig accelerationConfig = SystemAPI.GetSingleton<CEngineAccelerationConfig>();
            
            Entities
                .WithAll<CShip>()
                .WithAll<CMovable>()
                .ForEach((ref CMoveDirection direction) =>
                {
                    direction.Vector *= accelerationConfig.FrameMultiplier;
                })
                .Run();
        }
    }
}
