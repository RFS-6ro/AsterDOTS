// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using UnityEngine;

namespace Update.PowerUps.Shooting.BulletSpeedChange
{
    public class CBulletSpeedChangeAuthority : MonoBehaviour
    {
        [SerializeField] private EntityType _targetBullets = EntityType.PlayerBullet;
        [SerializeField] private float _multiplier = 2f;

        public EntityType TargetBullets => _targetBullets;
        public float Multiplier => _multiplier;
    }
}
