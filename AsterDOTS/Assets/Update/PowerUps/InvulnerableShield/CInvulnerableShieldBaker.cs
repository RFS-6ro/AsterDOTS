// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.PowerUps.InvulnerableShield
{
    public class CInvulnerableShieldBaker : Baker<CInvulnerableShieldAuthority>
    {
        public override void Bake(CInvulnerableShieldAuthority authoring)
        {
            AddComponent(new CInvulnerableShield());
        }
    }
}