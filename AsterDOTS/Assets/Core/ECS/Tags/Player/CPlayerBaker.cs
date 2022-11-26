// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Player
{
    public class CPlayerBaker : Baker<CPlayerAuthority>
    {
        public override void Bake(CPlayerAuthority auth)
        {
            AddComponent(new CPlayer());
        }
    }
}
