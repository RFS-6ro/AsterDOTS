// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Weapons.Delay
{
    public struct CBulletShotDelay : IComponentData
    {
        public double LastShotTime;
    }
}
