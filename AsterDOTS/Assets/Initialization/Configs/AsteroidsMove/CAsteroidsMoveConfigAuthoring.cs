// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.AsteroidsMove
{
    public class CAsteroidsMoveConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private float _asteroidSmallSpeed          = 20;
        [SerializeField] private float _asteroidSmallRotationSpeed  = 3;
        [Space]
        [SerializeField] private float _asteroidMediumSpeed         = 15;
        [SerializeField] private float _asteroidMediumRotationSpeed = 2;
        [Space]
        [SerializeField] private float _asteroidBigSpeed            = 10;
        [SerializeField] private float _asteroidBigRotationSpeed    = 1;
        
        public float AsteroidSmallSpeed         => _asteroidSmallSpeed;
        public float AsteroidSmallRotationSpeed => _asteroidSmallRotationSpeed;
        public float AsteroidMediumSpeed        => _asteroidMediumSpeed;
        public float AsteroidMediumRotationSpeed=> _asteroidMediumRotationSpeed;
        public float AsteroidBigSpeed           => _asteroidBigSpeed;
        public float AsteroidBigRotationSpeed   => _asteroidBigRotationSpeed;
    }
}
