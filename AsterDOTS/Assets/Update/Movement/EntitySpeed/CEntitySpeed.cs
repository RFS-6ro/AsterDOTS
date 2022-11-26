// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.PlayerMovement
{
    public struct CEntitySpeed : IComponentData
    {
        public float RotationMultiplier;

        public float SpeedMultiplier;
    }
}
