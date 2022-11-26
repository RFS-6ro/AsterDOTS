// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AlienShipMove
{
    public struct CAlienShipMoveConfig : IComponentData
    {
        public float AlienShipSmallSpeed;
        public float AlienShipSmallRotationSpeed;
        
        public float AlienShipBigSpeed;
        public float AlienShipBigRotationSpeed;
    }
}
