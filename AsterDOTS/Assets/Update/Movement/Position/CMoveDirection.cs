// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Unity.Mathematics;

namespace Update.Movement.Position
{
    public struct CMoveDirection : IComponentData
    {
        public float3 Vector;
    }
}
