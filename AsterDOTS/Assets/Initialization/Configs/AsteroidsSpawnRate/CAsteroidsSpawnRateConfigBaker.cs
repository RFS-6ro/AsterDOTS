// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AsteroidsSpawnRate
{
    public class CAsteroidsSpawnRateConfigBaker : Baker<CAsteroidsSpawnRateConfigAuthoring>
    {
        public override void Bake(CAsteroidsSpawnRateConfigAuthoring auth)
        {
            AddComponent(new CAsteroidsSpawnRateConfig
            {
                Delay = auth.Delay,
                
                SmallAsteroidsAfterDestroy = auth.SmallAsteroidsAfterDestroy,
                MediumAsteroidsAfterDestroy = auth.MediumAsteroidsAfterDestroy,
                
                SmallAsteroidsSceneBuffer = auth.SmallAsteroidsSceneBuffer,
                MediumAsteroidsSceneBuffer = auth.MediumAsteroidsSceneBuffer,
                BigAsteroidsSceneBuffer = auth.BigAsteroidsSceneBuffer
            });
        }
    }
}
