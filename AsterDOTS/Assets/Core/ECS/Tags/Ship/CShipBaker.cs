// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Ship
{
    public class CShipBaker : Baker<CShipAuthority>
    {
        public override void Bake(CShipAuthority auth)
        {
            AddComponent(new CShip());
        }
    }
}
