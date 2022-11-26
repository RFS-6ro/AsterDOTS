// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.AlienShipSpawnRate
{
    public class CAlienShipSpawnRateConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private float _delay = 10f;
        
        [SerializeField] private int _smallAlienShipSceneBuffer = 4;
        [SerializeField] private int _bigAlienShipSceneBuffer = 2;

        public float Delay => _delay;
        
        public int SmallAlienShipSceneBuffer => _smallAlienShipSceneBuffer;
        public int BigAlienShipSceneBuffer => _bigAlienShipSceneBuffer;
    }
}
