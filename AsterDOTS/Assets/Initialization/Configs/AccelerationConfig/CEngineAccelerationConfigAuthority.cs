// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.AccelerationConfig
{
    public class CEngineAccelerationConfigAuthority : MonoBehaviour
    {
        [SerializeField] private float _frameMultiplier;

        public float FrameMultiplier => _frameMultiplier;
    }
}