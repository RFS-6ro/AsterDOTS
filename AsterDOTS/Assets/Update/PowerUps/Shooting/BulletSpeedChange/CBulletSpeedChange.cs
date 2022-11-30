// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using Unity.Entities;

namespace Update.PowerUps.Shooting.BulletSpeedChange
{
    public struct CBulletSpeedChange : IComponentData
    {
        public EntityType TargetBullets;
        
        public float Multiplier;
    }
}
