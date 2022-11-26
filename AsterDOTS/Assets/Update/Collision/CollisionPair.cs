// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

namespace Update.Collision
{
    public struct CollisionPair
    {
        public int EntityA;
        public int EntityB;

        public bool Equals(CollisionPair other)
        {
            return (EntityA == other.EntityA || EntityA == other.EntityB && EntityB == other.EntityA || EntityB == other.EntityB);
        }
    }
}
