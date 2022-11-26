// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Update.Weapons.Stats
{
    public class CWeaponStatsAuthority : MonoBehaviour
    {
        [SerializeField] private float _shotDelay;

        public float ShotDelay => _shotDelay;
    }
}
