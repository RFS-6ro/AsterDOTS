// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.PowerUp
{
    public class CPowerUpSpawnConfigAuthority : MonoBehaviour
    {
        [Range(0.01f, 1f)] [SerializeField] private float _rate = 0.2f;

        public float Rate => _rate;
    }
}
