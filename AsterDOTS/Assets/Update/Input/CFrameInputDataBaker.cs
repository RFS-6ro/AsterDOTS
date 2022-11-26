// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Input
{
    public class CFrameInputDataBaker : Baker<CFrameInputDataAuthority>
    {
        public override void Bake(CFrameInputDataAuthority auth)
        {
            AddComponent(new CFrameInputData());
        }
    }
}
