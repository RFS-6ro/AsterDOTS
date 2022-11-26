// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Unit
{
    public class CUnitBaker : Baker<CUnitAuthority>
    {
        public override void Bake(CUnitAuthority auth)
        {
            AddComponent(new CUnit
            {
                EntityType = auth.EntityType
            });
        }
    }
}
