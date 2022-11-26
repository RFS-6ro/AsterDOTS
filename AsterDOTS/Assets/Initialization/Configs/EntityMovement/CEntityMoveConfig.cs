// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.EntityMovement
{
    public struct CEntityMoveConfig : IComponentData
    {
        public float PlayerShipSpeed;
        public float PlayerShipRotationSpeed;
        public float PowerUpPlaceholderSpeed;
    }
}
