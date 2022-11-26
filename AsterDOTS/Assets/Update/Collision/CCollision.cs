// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using Unity.Entities;

namespace Update.Collision
{
    public struct EntityData
    {
        public Entity Entity;
        public EntityType Type;
    }
    
    public struct CCollision : IComponentData
    {
        public EntityType OwnerEntityType;
        public EntityType OtherEntityType;
    }
    
    
}
