// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System.Linq;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Initialization.Configs.SpawnPoints
{
    public class CSpawnPointsConfigBaker : Baker<CSpawnPointsConfigAuthority>
    {
        public override void Bake(CSpawnPointsConfigAuthority auth)
        {
            AddComponent(new CSpawnPointsConfig
            {
                Count = auth.Points.Count(),
                Points = new NativeArray<float3>(auth.Points.ToArray(), Allocator.Persistent),
                Forwards = new NativeArray<float3>(auth.Forwards.ToArray(), Allocator.Persistent)
            });
        }
    }
}
