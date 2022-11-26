// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Movable
{
    public class CMovableBaker : Baker<CMovableAuthority>
    {
        public override void Bake(CMovableAuthority auth)
        {
            AddComponent(new CMovable());
        }
    }
}
