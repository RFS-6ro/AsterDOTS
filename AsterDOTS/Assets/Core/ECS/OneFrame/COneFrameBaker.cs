// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.OneFrame
{
    public class COneFrameBaker : Baker<COneFrameAuthoring>
    {
        public override void Bake(COneFrameAuthoring auth)
        {
            AddComponent(new COneFrame
            {
                FramesActive = auth.FramesActive
            });
        }
    }
}
