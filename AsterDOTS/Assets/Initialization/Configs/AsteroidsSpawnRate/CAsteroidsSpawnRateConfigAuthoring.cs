// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Initialization.Configs.AsteroidsSpawnRate
{
    public class CAsteroidsSpawnRateConfigAuthoring : MonoBehaviour
    {
        [SerializeField] private float _delay = 8f;
        [Space]
        [SerializeField] private int _smallAsteroidsAfterDestroy = 2;
        [SerializeField] private int _mediumAsteroidsAfterDestroy = 2;
        [Space]
        [SerializeField] private int _smallAsteroidsSceneBuffer = 8;
        [SerializeField] private int _mediumAsteroidsSceneBuffer = 4;
        [SerializeField] private int _bigAsteroidsSceneBuffer = 2;

        public float Delay => _delay;
        
        public int SmallAsteroidsAfterDestroy => _smallAsteroidsAfterDestroy;
        public int MediumAsteroidsAfterDestroy => _mediumAsteroidsAfterDestroy;

        public int SmallAsteroidsSceneBuffer => _smallAsteroidsSceneBuffer;
        public int MediumAsteroidsSceneBuffer => _mediumAsteroidsSceneBuffer;
        public int BigAsteroidsSceneBuffer => _bigAsteroidsSceneBuffer;
    }
}
