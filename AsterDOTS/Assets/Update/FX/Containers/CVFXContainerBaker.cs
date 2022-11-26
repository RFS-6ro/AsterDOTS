// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.FX.Containers
{
    public class CVFXContainerBaker : Baker<CVFXContainerAuthority>
    {
        public override void Bake(CVFXContainerAuthority auth)
        {
            AddComponent(new CVFXContainer
            {
                Container = GetEntity(auth.Container)
            });
        }
    }
}
