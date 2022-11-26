// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Spawners.Bullets
{
    public class CBulletShotRequestBaker : Baker<CBulletShotRequestAuthority>
    {
        public override void Bake(CBulletShotRequestAuthority auth)
        {
            AddComponent(new CBulletShotRequest
            {
                Type = auth.Type
            });
        }
    }
}
