// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.BulletMove
{
    public class CBulletMoveConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private float _enemyBulletSpeed = 17;
        [SerializeField] private float _playerBulletSpeed = 17;
        
        public float EnemyBulletSpeed => _enemyBulletSpeed;
        public float PlayerBulletSpeed => _playerBulletSpeed;
    }
}
