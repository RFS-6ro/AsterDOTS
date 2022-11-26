// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Initialization.Configs;
using UnityEngine;

namespace Core.ECS.Tags.Unit
{
    public class CUnitAuthority : MonoBehaviour
    {
        [SerializeField] private EntityType _entityType;

        public EntityType EntityType => _entityType;
    }
}
