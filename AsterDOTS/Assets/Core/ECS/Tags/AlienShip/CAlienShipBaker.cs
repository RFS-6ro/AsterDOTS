// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Asteroid;
using Unity.Entities;

namespace Core.ECS.Tags.AlienShip
{
    public class CAlienShipBaker : Baker<CAlienShipAuthority>
    {
        public override void Bake(CAlienShipAuthority auth)
        {
            AddComponent(new CAlienShip());
        }
    }
}
