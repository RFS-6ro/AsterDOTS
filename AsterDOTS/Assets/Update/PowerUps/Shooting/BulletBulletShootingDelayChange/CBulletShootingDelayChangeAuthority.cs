// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Update.PowerUps.Shooting.BulletBulletShootingDelayChange
{
    public class CBulletShootingDelayChangeAuthority : MonoBehaviour
    {
        [SerializeField] private float _multiplier = 2f;

        public float Multiplier => _multiplier;
    }
}
