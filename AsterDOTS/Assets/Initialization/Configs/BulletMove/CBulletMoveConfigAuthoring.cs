// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.BulletMove
{
    public class CBulletMoveConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed                 = 30;
        public float BulletSpeed                => _bulletSpeed;
    }
}
