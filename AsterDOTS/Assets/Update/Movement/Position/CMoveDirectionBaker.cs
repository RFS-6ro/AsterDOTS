﻿// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Update.Movement.Position
{
    public class CMoveDirectionBaker : Baker<CMoveDirectionAuthority>
    {
        public override void Bake(CMoveDirectionAuthority auth)
        {
            AddComponent(new CMoveDirection
            {
                Vector = auth.Vector
            });
        }
    }
}
