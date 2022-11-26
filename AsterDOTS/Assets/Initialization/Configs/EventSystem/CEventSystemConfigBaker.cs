// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.EventSystem
{
    public class CEventSystemConfigBaker : Baker<CEventSystemConfigAuthority>
    {
        public override void Bake(CEventSystemConfigAuthority auth)
        {
            AddComponent(new CEventSystemConfig
            {
                EventPrefab = GetEntity(auth.EventPrefab)
            });
        }
    }
}
