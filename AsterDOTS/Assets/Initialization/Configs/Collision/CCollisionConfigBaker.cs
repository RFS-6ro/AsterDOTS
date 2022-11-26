// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.Collision
{
    public class CCollisionConfigBaker : Baker<CCollisionConfigAuthority>
    {
        public override void Bake(CCollisionConfigAuthority auth)
        {
            AddComponent(new CCollisionConfig
            {
                Delay = auth.Delay
            });
        }
    }
}
