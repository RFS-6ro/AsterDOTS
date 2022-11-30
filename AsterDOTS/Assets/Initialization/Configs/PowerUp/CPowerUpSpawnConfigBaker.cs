// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.PowerUp
{
    public class CPowerUpSpawnConfigBaker : Baker<CPowerUpSpawnConfigAuthority>
    {
        public override void Bake(CPowerUpSpawnConfigAuthority auth)
        {
            AddComponent(new CPowerUpSpawnConfig
            {
                Rate = auth.Rate
            });
        }
    }
}
