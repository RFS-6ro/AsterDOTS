// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Health
{
    public class CHealthBaker : Baker<CHealthAuthority>
    {
        public override void Bake(CHealthAuthority auth)
        {
            AddComponent(new CHealth
            {
                Amount = auth.Amount
            });
        }
    }
}
