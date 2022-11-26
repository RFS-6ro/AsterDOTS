// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AsteroidsMove
{
    public struct CAsteroidsMoveConfig : IComponentData
    {
        public float AsteroidSmallSpeed;
        public float AsteroidSmallRotationSpeed;
        
        public float AsteroidMediumSpeed;
        public float AsteroidMediumRotationSpeed;
        
        public float AsteroidBigSpeed;
        public float AsteroidBigRotationSpeed;
    }
}
