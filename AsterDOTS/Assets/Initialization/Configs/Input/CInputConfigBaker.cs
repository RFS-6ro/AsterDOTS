// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.Input
{
    public class CInputConfigBaker : Baker<CInputConfigAuthoring>
    {
        public override void Bake(CInputConfigAuthoring auth)
        {
            AddComponent(new CInputConfig
            {
                ShootKey = auth.ShootKey,
                AccelerationKey = auth.AccelerationKey,
                TurnLeftKey = auth.TurnLeftKey,
                TurnRightKey = auth.TurnRightKey
            });
        }
    }
}
