// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Unity.Mathematics;

namespace Update.Movement.InstantTransformChanger
{
    public struct CChangeTransformRequest : IComponentData
    {
        public float3 Position;

        public quaternion Rotation;
    }
}
