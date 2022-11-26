// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.Collision
{
    public class CCollisionConfigAuthority : MonoBehaviour
    {
        [SerializeField] private float _delay = 1f;

        public float Delay => _delay;
    }
}
