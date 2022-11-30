// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.EntityPrefabs
{
    public struct CEntityPrefabsConfig : IComponentData
    {
        public Entity PlayerShipPrefab;
        public Entity AlienShipSmallPrefab;
        public Entity AlienShipBigPrefab;
        public Entity AsteroidSmallPrefab;
        public Entity AsteroidMediumPrefab;
        public Entity AsteroidBigPrefab;
        public Entity WeaponPrefab;
        public Entity PlayerBullet;
        public Entity EnemyBullet;
        public Entity InvulnerableShieldPrefab;
        public Entity BulletSpeedIncreasePrefab;
        public Entity BulletShootingDelayDecrease;
    }
}
