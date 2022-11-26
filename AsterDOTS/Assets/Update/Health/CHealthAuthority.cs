// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Update.Health
{
    public class CHealthAuthority : MonoBehaviour
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;
    }
}
