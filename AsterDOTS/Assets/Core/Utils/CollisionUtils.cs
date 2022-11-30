// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System.Linq;
using Core.ECS.Tags.Unit;
using Initialization.Configs;
using Unity.Entities;
using UnityEngine;
using Update.Collision;

namespace Core.Utils
{
    public static class CollisionUtils
    {
        public static bool IsBoundaryCollision(this CCollisionData data) => 
            data.A.Type == EntityType.Boundary || data.B.Type == EntityType.Boundary;

        public static Entity GetNonBoundary(this CCollisionData data)
        {
            if (!data.IsBoundaryCollision())
            {
                Debug.LogError("Trying to get non boundary entity from non boundary collision");
            }

            return data.A.Type == EntityType.Boundary ? data.B.Entity : data.A.Entity;
        }
        
        public static bool TryGetPowerUpCollision
        (
            this ComponentLookup<CUnit> unitFilter, 
            CCollisionData data,
            out EntityData picker, 
            out EntityData powerUp
        )
        {
            picker = default;
            powerUp = default;
            
            if (!unitFilter.TryGetComponent(data.A.Entity, out CUnit unitA)) { return false; }
            if (!unitFilter.TryGetComponent(data.B.Entity, out CUnit unitB)) { return false; }

            bool isA = unitA.IsPowerUp();
            bool isB = unitB.IsPowerUp();

            if (!isA && !isB || isA && isB) { return false; }

            EntityData entityA = new EntityData
            {
                Entity = data.A.Entity,
                Type = unitA.EntityType
            };

            EntityData entityB = new EntityData
            {
                Entity = data.B.Entity,
                Type = unitB.EntityType
            };
            
            powerUp = isA ? entityA : entityB;
            picker = isA ? entityB : entityA;
            
            return true;
        }

        public static bool IsPowerUp(this CUnit unit) =>
            unit.EntityType >= EntityType.InvulnerableShield 
            && unit.EntityType <= EntityType.BulletShootingDelayDecrease;
    }
}
