// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using UnityEngine;

namespace Core.ECS.Random
{
    public class CRandomAuthoring : MonoBehaviour
    {
        [SerializeField] private bool _useSystemTime = true;
        [SerializeField] private uint _seed;

        public uint Seed => _useSystemTime 
            ? (uint)DateTime.UtcNow.Millisecond 
            : _seed;
    }
}
