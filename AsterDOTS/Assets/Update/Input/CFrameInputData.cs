// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Input
{
    public struct CFrameInputData : IComponentData
    {
        public bool Acceleration;
        public float Rotation;
        public bool IsShotRequested;
    }
}
