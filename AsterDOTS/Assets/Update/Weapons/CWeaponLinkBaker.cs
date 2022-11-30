// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Weapons
{
    public class CWeaponLinkBaker : Baker<CWeaponLinkAuthority>
    {
        public override void Bake(CWeaponLinkAuthority auth)
        {
            AddComponent(new CWeaponLink
            {
                Weapon = GetEntity(auth.Weapon)
            });
        }
    }
}
