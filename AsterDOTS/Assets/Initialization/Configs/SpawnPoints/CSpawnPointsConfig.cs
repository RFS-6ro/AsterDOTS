// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Initialization.Configs.SpawnPoints
{
    public struct CSpawnPointsConfig : IComponentData
    {
        public int Count;
        public NativeArray<float3> Points;
        public NativeArray<float3> Forwards;
    }
}
