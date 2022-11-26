﻿// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.InputListener
{
    public class CInputListenerBaker : Baker<CInputListenerAuthority>
    {
        public override void Bake(CInputListenerAuthority auth)
        {
            AddComponent(new CInputListener());
        }
    }
}
