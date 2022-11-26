// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AsteroidsSpawnRate
{
    public struct CAsteroidsSpawnRateConfig : IComponentData
    {
        public float Delay;
        
        public int SmallAsteroidsAfterDestroy;
        public int MediumAsteroidsAfterDestroy;

        public int SmallAsteroidsSceneBuffer;
        public int MediumAsteroidsSceneBuffer;
        public int BigAsteroidsSceneBuffer;
    }
}
