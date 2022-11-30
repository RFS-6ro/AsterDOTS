// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.PowerUp
{
    public class CPowerUpBaker : Baker<CPowerUpAuthority>
    {
        public override void Bake(CPowerUpAuthority authoring)
        {
            AddComponent(new CPowerUp());
        }
    }
}
