// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AlienShipSpawnRate
{
    public class CAlienShipSpawnRateConfigBaker : Baker<CAlienShipSpawnRateConfigAuthoring>
    {
        public override void Bake(CAlienShipSpawnRateConfigAuthoring auth)
        {
            AddComponent(new CAlienShipSpawnRateConfig
            {
                Delay = auth.Delay,
                
                SmallAlienShipSceneBuffer = auth.SmallAlienShipSceneBuffer,
                BigAlienShipSceneBuffer = auth.BigAlienShipSceneBuffer
            });
        }
    }
}
