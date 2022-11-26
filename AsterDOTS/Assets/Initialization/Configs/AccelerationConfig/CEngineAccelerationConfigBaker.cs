// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AccelerationConfig
{
    public class CEngineAccelerationConfigBaker : Baker<CEngineAccelerationConfigAuthority>
    {
        public override void Bake(CEngineAccelerationConfigAuthority auth)
        {
            AddComponent(new CEngineAccelerationConfig
            {
                FrameMultiplier = auth.FrameMultiplier
            });
        }
    }
}
