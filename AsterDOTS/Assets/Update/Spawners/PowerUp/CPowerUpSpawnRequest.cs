// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Unity.Mathematics;

namespace Update.Spawners.PowerUp
{
    public struct CPowerUpSpawnRequest : IComponentData
    {
        public float3 Position;
    }
}
