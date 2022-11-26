// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.FX.Containers
{
    public class CSFXContainerBaker : Baker<CSFXContainerAuthority>
    {
        public override void Bake(CSFXContainerAuthority auth)
        {
            AddComponent(new CSFXContainer
            {
                Container = GetEntity(auth.Container)
            });
        }
    }
}
