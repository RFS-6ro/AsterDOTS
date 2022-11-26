// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.AlienShipSpawnRate
{
    public struct CAlienShipSpawnRateConfig : IComponentData
    {
        public float Delay;
        
        public int SmallAlienShipSceneBuffer;
        public int BigAlienShipSceneBuffer;
    }
}
