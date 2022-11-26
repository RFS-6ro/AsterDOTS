// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using Unity.Entities;

namespace Update.Spawners.Bullets
{
    public struct CBulletShotRequest : IComponentData
    {
        public EntityType Type;

        public bool IsActive;
        
        public bool InProgress;
    }
}
