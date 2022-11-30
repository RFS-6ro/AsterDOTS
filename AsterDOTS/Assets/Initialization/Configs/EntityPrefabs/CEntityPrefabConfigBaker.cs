// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.EntityPrefabs
{
    public class CEntityPrefabConfigBaker : Baker<CEntityPrefabConfigAuthority>
    {
        public override void Bake(CEntityPrefabConfigAuthority auth)
        {
            AddComponent(new CEntityPrefabsConfig
            {
                PlayerShipPrefab         = GetEntity(auth.PlayerShipPrefab), 
                AlienShipSmallPrefab     = GetEntity(auth.AlienShipSmallPrefab), 
                AlienShipBigPrefab       = GetEntity(auth.AlienShipBigPrefab), 
                AsteroidSmallPrefab      = GetEntity(auth.AsteroidSmallPrefab), 
                AsteroidMediumPrefab     = GetEntity(auth.AsteroidMediumPrefab), 
                AsteroidBigPrefab        = GetEntity(auth.AsteroidBigPrefab), 
                WeaponPrefab             = GetEntity(auth.WeaponPrefab), 
                PlayerBullet             = GetEntity(auth.PlayerBullet),
                EnemyBullet              = GetEntity(auth.EnemyBullet),
                InvulnerableShieldPrefab = GetEntity(auth.InvulnerableShieldPrefab),
                BulletSpeedIncreasePrefab = GetEntity(auth.BulletSpeedIncreasePrefab),
                BulletShootingDelayDecrease = GetEntity(auth.BulletShootingDelayDecreasePrefab),
            });
        }
    }
}
