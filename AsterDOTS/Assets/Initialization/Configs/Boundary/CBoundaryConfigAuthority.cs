// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.Boundary
{
    [RequireComponent(typeof(BoxCollider))]
    public class CBoundaryConfigAuthority : MonoBehaviour
    {
        [SerializeField] private GameObject _parentEntity;

        public GameObject ParentEntity => _parentEntity;
    }
}
