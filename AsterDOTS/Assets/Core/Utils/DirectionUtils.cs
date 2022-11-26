// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Mathematics;
using UnityEngine;

namespace Core.Utils
{
    public static class DirectionUtils
    {
        public static float3 Forward() => new float3(0f, 0f, 1f);
        public static float3 Up() => new float3(0f, 1f, 0f);
        
        public static float GetRotationBetween(this float3 from, float3 to)
        {
            return Vector3.Angle(from, to);
        }
    }
}
