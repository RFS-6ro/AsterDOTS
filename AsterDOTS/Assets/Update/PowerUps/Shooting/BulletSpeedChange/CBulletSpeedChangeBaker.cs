// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.PowerUps.Shooting.BulletSpeedChange
{
    public class CBulletSpeedChangeBaker : Baker<CBulletSpeedChangeAuthority>
    {
        public override void Bake(CBulletSpeedChangeAuthority auth)
        {
            AddComponent(new CBulletSpeedChange
            {
                TargetBullets = auth.TargetBullets,
                Multiplier = auth.Multiplier
            });
        }
    }
}
