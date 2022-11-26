// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Weapons.Stats
{
    public class CWeaponStatsBaker : Baker<CWeaponStatsAuthority>
    {
        public override void Bake(CWeaponStatsAuthority auth)
        {
            AddComponent(new CWeaponStats
            {
                ShotDelay = auth.ShotDelay
            });
        }
    }
}
