// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AlienShipMove
{
    public class CAlienShipMoveConfigBaker : Baker<CAlienShipMoveConfigAuthoring>
    {
        public override void Bake(CAlienShipMoveConfigAuthoring auth)
        {
            AddComponent(new CAlienShipMoveConfig
            {
                AlienShipSmallSpeed = auth.AlienShipSmallSpeed,
                AlienShipSmallRotationSpeed = auth.AlienShipSmallRotationSpeed,
                AlienShipBigSpeed = auth.AlienShipBigSpeed,
                AlienShipBigRotationSpeed = auth.AlienShipBigRotationSpeed,
            });
        }
    }
}
