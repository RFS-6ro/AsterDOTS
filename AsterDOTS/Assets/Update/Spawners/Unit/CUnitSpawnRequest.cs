// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Update.Spawners.Unit
{
    public struct CUnitSpawnRequest : IComponentData
    {
        public int Count;
        public NativeArray<EntityType> UnitTypes;
        public NativeArray<float3> Positions;
        public NativeArray<float3> Directions;
    }
}
