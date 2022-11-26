// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using UnityEngine;

namespace Initialization.Configs.Boundary
{
    public struct CBoundaryConfig : IComponentData
    {
        public Entity ParentEntity;
        public Bounds Bounds;
        public int X;
        public int Y;
    }
}
