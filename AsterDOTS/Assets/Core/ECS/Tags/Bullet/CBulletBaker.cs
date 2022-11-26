// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Bullet
{
    public class CBulletBaker : Baker<CBulletAuthority>
    {
        public override void Bake(CBulletAuthority auth)
        {
            AddComponent(new CBullet());
        }
    }
}
