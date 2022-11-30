// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Update.Weapons
{
    public class CWeaponLinkAuthority : MonoBehaviour
    {
        [SerializeField] private GameObject _weapon;

        public GameObject Weapon => _weapon;
    }
}