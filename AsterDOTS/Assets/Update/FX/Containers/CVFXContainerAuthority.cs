// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Update.FX.Containers
{
    public class CVFXContainerAuthority : MonoBehaviour
    {
        [SerializeField] private GameObject _container;

        public GameObject Container => _container;
    }
}
