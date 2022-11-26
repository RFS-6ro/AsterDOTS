// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.EventSystem
{
    public class CEventSystemConfigAuthority : MonoBehaviour
    {
        [SerializeField] private GameObject eventPrefab;
        
        public GameObject EventPrefab => eventPrefab;
    }
}
