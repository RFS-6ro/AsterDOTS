// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.AlienShipMove
{
    public class CAlienShipMoveConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private float _alienShipSmallSpeed         = 20;
        [SerializeField] private float _alienShipSmallRotationSpeed = 2;
        [Space]
        [SerializeField] private float _alienShipBigSpeed           = 10;
        [SerializeField] private float _alienShipBigRotationSpeed   = 1;
        
        public float AlienShipSmallSpeed        => _alienShipSmallSpeed;
        public float AlienShipSmallRotationSpeed=> _alienShipSmallRotationSpeed;
        public float AlienShipBigSpeed          => _alienShipBigSpeed;
        public float AlienShipBigRotationSpeed  => _alienShipBigRotationSpeed;
    }
}
