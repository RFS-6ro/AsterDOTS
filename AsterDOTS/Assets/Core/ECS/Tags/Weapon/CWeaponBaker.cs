// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Weapon
{
    public class CWeaponBaker : Baker<CWeaponAuthority>
    {
        public override void Bake(CWeaponAuthority auth)
        {
            AddComponent(new CWeapon());
        }
    }
}
