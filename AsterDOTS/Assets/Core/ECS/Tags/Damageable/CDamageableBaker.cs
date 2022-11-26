// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Damageable
{
    public class CDamageableBaker : Baker<CDamageableAuthority>
    {
        public override void Bake(CDamageableAuthority auth)
        {
            AddComponent(new CDamageable());
        }
    }
}
