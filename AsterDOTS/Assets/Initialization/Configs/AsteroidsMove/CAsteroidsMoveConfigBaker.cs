// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AsteroidsMove
{
    public class CAsteroidsMoveConfigBaker : Baker<CAsteroidsMoveConfigAuthoring>
    {
        public override void Bake(CAsteroidsMoveConfigAuthoring auth)
        {
            AddComponent(new CAsteroidsMoveConfig
            {
                AsteroidSmallSpeed = auth.AsteroidSmallSpeed,
                AsteroidSmallRotationSpeed = auth.AsteroidSmallRotationSpeed,
                AsteroidMediumSpeed = auth.AsteroidMediumSpeed,
                AsteroidMediumRotationSpeed = auth.AsteroidMediumRotationSpeed,
                AsteroidBigSpeed = auth.AsteroidBigSpeed,
                AsteroidBigRotationSpeed = auth.AsteroidBigRotationSpeed,
            });
        }
    }
}
