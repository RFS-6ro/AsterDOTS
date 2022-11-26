// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using UnityEngine;

namespace Initialization.Configs.EntityPrefabs
{
    public class CEntityPrefabConfigAuthority : MonoBehaviour
    {
        [SerializeField] private GameObject _playerShipPrefab;
        [SerializeField] private GameObject _alienShipSmallPrefab;
        [SerializeField] private GameObject _alienShipBigPrefab;
        [SerializeField] private GameObject _asteroidSmallPrefab;
        [SerializeField] private GameObject _asteroidMediumPrefab;
        [SerializeField] private GameObject _asteroidBigPrefab;
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private GameObject _playerBullet;
        [SerializeField] private GameObject _enemyBullet;
        [SerializeField] private GameObject _powerUpPlaceholderPrefab;
        
        public GameObject PlayerShipPrefab         => _playerShipPrefab;
        public GameObject AlienShipSmallPrefab     => _alienShipSmallPrefab;
        public GameObject AlienShipBigPrefab       => _alienShipBigPrefab;
        public GameObject AsteroidSmallPrefab      => _asteroidSmallPrefab;
        public GameObject AsteroidMediumPrefab     => _asteroidMediumPrefab;
        public GameObject AsteroidBigPrefab        => _asteroidBigPrefab;
        public GameObject WeaponPrefab             => _weaponPrefab;
        public GameObject PlayerBullet             => _playerBullet;
        public GameObject EnemyBullet              => _enemyBullet;
        public GameObject PowerUpPlaceholderPrefab => _powerUpPlaceholderPrefab;
    }
}
