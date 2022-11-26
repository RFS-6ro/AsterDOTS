// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.EntityMovement
{
    public class CEntityMoveConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private float _playerShipSpeed             = 15;
        [SerializeField] private float _playerShipRotationSpeed     = 3;
        [SerializeField] private float _powerUpPlaceholderSpeed     = 5;
        
        public float PlayerShipSpeed            => _playerShipSpeed;
        public float PlayerShipRotationSpeed    => _playerShipRotationSpeed;
        public float PowerUpPlaceholderSpeed    => _powerUpPlaceholderSpeed;
    }
}
