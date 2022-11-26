// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using UnityEngine;

namespace Update.Spawners.Bullets
{
    public class CBulletShotRequestAuthority : MonoBehaviour
    {
        [SerializeField] private EntityType _type;
        
        public EntityType Type => _type;
    }
}
