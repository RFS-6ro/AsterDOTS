// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.Input
{
    public class CInputConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private KeyCode _shootKey = KeyCode.Space;
        [SerializeField] private KeyCode _accelerationKey = KeyCode.W;
        [SerializeField] private KeyCode _turnLeftKey = KeyCode.A;
        [SerializeField] private KeyCode _turnRightKey = KeyCode.D;

        public KeyCode ShootKey => _shootKey;
        public KeyCode AccelerationKey => _accelerationKey;
        public KeyCode TurnLeftKey => _turnLeftKey;
        public KeyCode TurnRightKey => _turnRightKey;
    }
}
