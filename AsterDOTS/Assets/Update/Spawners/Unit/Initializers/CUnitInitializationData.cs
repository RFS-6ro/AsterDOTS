// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using Unity.Entities;

namespace Update.Spawners.Unit.Initializers
{
    public struct CUnitInitializationData : IComponentData
    {
        public EntityType UnitType;
    }
}
