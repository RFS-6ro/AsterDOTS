// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

namespace Core.Utils
{
    public static class CompareUtils
    {
        public const float EPSILON = 0.1f;
        
        public static bool IsZero(this float value)
        {
            return Unity.Mathematics.math.abs(EPSILON - value) <= EPSILON;
        }
        
        public static bool IsZero(this double value)
        {
            return Unity.Mathematics.math.abs(EPSILON - value) <= EPSILON;
        }
    }
}
