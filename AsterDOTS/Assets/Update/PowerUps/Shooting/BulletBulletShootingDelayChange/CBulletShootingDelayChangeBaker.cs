// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.PowerUps.Shooting.BulletBulletShootingDelayChange
{
    public class CBulletShootingDelayChangeBaker : Baker<CBulletShootingDelayChangeAuthority>
    {
        public override void Bake(CBulletShootingDelayChangeAuthority auth)
        {
            AddComponent(new CBulletShootingDelayChange
            {
                Multiplier = auth.Multiplier
            });
        }
    }
}
