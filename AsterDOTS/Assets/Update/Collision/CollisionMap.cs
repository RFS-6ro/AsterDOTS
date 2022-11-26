// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Unity.Collections;
using UnityEngine;

namespace Update.Collision
{
    public struct CollisionMap
    {
        private int _index;
        private int _capacity;
        
        private NativeArray<CollisionPair> _collisionPairs;
        
        public CollisionMap(int capacity)
        {
            if (capacity <= 0) { throw new ArgumentException("Capacity should be more, than zero", nameof(capacity)); }

            _index = 0;
            _capacity = capacity;
            _collisionPairs = new NativeArray<CollisionPair>(_capacity, Allocator.TempJob);
        }

        public bool TryAddPair(int entityA, int entityB)
        {
            if (_index == _capacity)
            {
                Debug.LogError("Collision map capacity exceed");
                return false;
            }
            
            CollisionPair pair = new CollisionPair
            {
                EntityA = entityA,
                EntityB = entityB
            };
            
            if (ContainsPair(pair))
            {
                return false;
            }
            
            _collisionPairs[_index] = pair;
            ++_index;
            return true;
        }

        public bool ContainsPair(CollisionPair pair)
        {
            for (int i = 0; i < _index; i++)
            {
                if (_collisionPairs[i].Equals(pair))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
