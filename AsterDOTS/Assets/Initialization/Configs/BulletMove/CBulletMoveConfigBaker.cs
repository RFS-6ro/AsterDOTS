// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.BulletMove
{
    public class CBulletMoveConfigBaker : Baker<CBulletMoveConfigAuthoring>
    {
        public override void Bake(CBulletMoveConfigAuthoring auth)
        {
            AddComponent(new CBulletMoveConfig
            {
                EnemyBulletSpeed = auth.EnemyBulletSpeed,
                PlayerBulletSpeed = auth.PlayerBulletSpeed,
            });
        }
    }
}
