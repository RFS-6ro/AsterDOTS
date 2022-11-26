// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using UnityEngine;

namespace Initialization.Configs.Input
{
    public struct CInputConfig : IComponentData
    {
        public KeyCode ShootKey;
        public KeyCode AccelerationKey;
        public KeyCode TurnLeftKey;
        public KeyCode TurnRightKey;
    }
}
