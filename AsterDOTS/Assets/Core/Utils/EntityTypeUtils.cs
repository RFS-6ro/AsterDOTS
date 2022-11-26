// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Initialization.Configs;
using Initialization.Configs.AlienShipMove;
using Initialization.Configs.AlienShipSpawnRate;
using Initialization.Configs.AsteroidsMove;
using Initialization.Configs.AsteroidsSpawnRate;
using Initialization.Configs.EntityPrefabs;
using Unity.Entities;

namespace Core.Utils
{
    public static class EntityTypeUtils
    {
        public static Entity GetEntityPrefab(this CEntityPrefabsConfig link, EntityType type)
        {
            switch (type)
            {
                case EntityType.PlayerShip: return link.PlayerShipPrefab;
                case EntityType.AsteroidSmall: return link.AsteroidSmallPrefab;
                case EntityType.AsteroidMedium: return link.AsteroidMediumPrefab;
                case EntityType.AsteroidBig: return link.AsteroidBigPrefab;
                case EntityType.AlienShipSmall: return link.AlienShipSmallPrefab;
                case EntityType.AlienShipBig: return link.AlienShipBigPrefab;
                case EntityType.Weapon: return link.WeaponPrefab;
                case EntityType.PlayerBullet: return link.PlayerBullet;
                case EntityType.EnemyBullet: return link.EnemyBullet;
                case EntityType.PowerUpPlaceholder: return link.PowerUpPlaceholderPrefab;
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static float GetEntitySpeed(this CAsteroidsMoveConfig speedConfig, EntityType type)
        {
            switch (type)
            {
                case EntityType.AsteroidSmall: return speedConfig.AsteroidSmallSpeed;
                case EntityType.AsteroidMedium: return speedConfig.AsteroidMediumSpeed;
                case EntityType.AsteroidBig: return speedConfig.AsteroidBigSpeed;
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        public static float GetEntitySpeed(this CAlienShipMoveConfig speedConfig, EntityType type)
        {
            switch (type)
            {
                case EntityType.AlienShipSmall: return speedConfig.AlienShipSmallSpeed;
                case EntityType.AlienShipBig: return speedConfig.AlienShipBigSpeed;
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        public static float GetEntityRotationSpeed(this CAlienShipMoveConfig speedConfig, EntityType type)
        {
            switch (type)
            {
                case EntityType.AlienShipSmall: return speedConfig.AlienShipSmallRotationSpeed;
                case EntityType.AlienShipBig: return speedConfig.AlienShipBigRotationSpeed;
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        public static float GetEntityRotationSpeed(this CAsteroidsMoveConfig speedConfig, EntityType type)
        {
            switch (type)
            {
                case EntityType.AsteroidSmall: return speedConfig.AsteroidSmallRotationSpeed;
                case EntityType.AsteroidMedium: return speedConfig.AsteroidMediumRotationSpeed;
                case EntityType.AsteroidBig: return speedConfig.AsteroidBigRotationSpeed;
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static int GetAsteroidSceneBufferCount(this CAsteroidsSpawnRateConfig spawnRate, EntityType type)
        {
            switch (type)
            {
                case EntityType.AsteroidSmall:  return spawnRate.SmallAsteroidsSceneBuffer;
                case EntityType.AsteroidMedium: return spawnRate.MediumAsteroidsSceneBuffer;
                case EntityType.AsteroidBig:    return spawnRate.BigAsteroidsSceneBuffer;
                default: return 0;
            }
        }

        public static int GetAlienShipSceneBufferCount(this CAlienShipSpawnRateConfig spawnRate, EntityType type)
        {
            switch (type)
            {
                case EntityType.AlienShipSmall:  return spawnRate.SmallAlienShipSceneBuffer;
                case EntityType.AlienShipBig:    return spawnRate.BigAlienShipSceneBuffer;
                default: return 0;
            }
        }
    }
}
