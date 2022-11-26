// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.PlayerMovement
{
    public class CEntitySpeedAuthoring : MonoBehaviour
    {
        [SerializeField] private float _rotationMultiplier = 1;
        [SerializeField] private float _speedMultiplier = 1;
        
        public float RotationMultiplier => _rotationMultiplier;
        public float SpeedMultiplier => _speedMultiplier;
    }
}
