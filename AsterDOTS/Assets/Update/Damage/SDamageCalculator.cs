// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Core.ECS.OneFrame;
using Initialization.Configs;
using Unity.Entities;
using UnityEngine;
using Update.Collision;
using Update.Movement.Rotation;

namespace Update.Damage
{
   // [UpdateAfter(typeof(SEntityRotateByAngle))]
    public partial class SDamageCalculator
    {
        protected void OnUpdate()
        {
            // EntityCommandBuffer entityCommandBuffer = SystemAPI
            //     .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
            //     .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            //Entities
                // .WithAll<COneFrame>()
                // .ForEach((CCollision collision) =>
                // {
                    // var first = collision.First;
                    // var second = collision.Second;
                    //
                    // string firstType = first.Type switch
                    // {
                    //     EntityType.None => "None",
                    //     EntityType.PlayerShip => "PlayerShip",
                    //     EntityType.AsteroidSmall => "AsteroidSmall",
                    //     EntityType.AsteroidMedium => "AsteroidMedium",
                    //     EntityType.AsteroidBig => "AsteroidBig",
                    //     EntityType.AlienShipSmall => "AlienShipSmall",
                    //     EntityType.AlienShipBig => "AlienShipBig",
                    //     EntityType.Weapon => "Weapon",
                    //     EntityType.Bullet => "Bullet",
                    //     EntityType.PowerUpPlaceholder => "PowerUpPlaceholder",
                    //     _ => "default"
                    // };
                    // string secondType = second.Type switch
                    // {
                    //     EntityType.None => "None",
                    //     EntityType.PlayerShip => "PlayerShip",
                    //     EntityType.AsteroidSmall => "AsteroidSmall",
                    //     EntityType.AsteroidMedium => "AsteroidMedium",
                    //     EntityType.AsteroidBig => "AsteroidBig",
                    //     EntityType.AlienShipSmall => "AlienShipSmall",
                    //     EntityType.AlienShipBig => "AlienShipBig",
                    //     EntityType.Weapon => "Weapon",
                    //     EntityType.Bullet => "Bullet",
                    //     EntityType.PowerUpPlaceholder => "PowerUpPlaceholder",
                    //     _ => "default"
                    // };
                    //
                    // Debug.Log($"FirstType = {firstType}, FirstEntity = {first.Entity}. SecondType = {secondType}, SecondEntity = {second.Entity}");

                    // if (EntityManager.HasComponent<CDamageable>(collision.First))
                    // {
                    // entityCommandBuffer.AddComponent(collision.First.Entity, new CDamage
                    // {
                    //     Amount = 1
                    // });
                    // }
                    //
                    // if (EntityManager.HasComponent<CDamageable>(collision.Second))
                    // {
                        // entityCommandBuffer.AddComponent(collision.Second.Entity, new CDamage
                        // {
                        //     Amount = 1
                        // });
                    // }
                // })
                // .Run();
        }
    }
}
