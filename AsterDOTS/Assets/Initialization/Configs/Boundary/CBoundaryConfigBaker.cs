// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using UnityEngine;

namespace Initialization.Configs.Boundary
{
    public class CBoundaryConfigBaker : Baker<CBoundaryConfigAuthority>
    {
        public override void Bake(CBoundaryConfigAuthority auth)
        {
            BoxCollider collider = auth.gameObject.GetComponent<BoxCollider>();
            AddComponent(new CBoundaryConfig
            {
                ParentEntity = GetEntity(auth.ParentEntity),
                Bounds = collider.bounds,
                X = Screen.width,
                Y = Screen.height
            });
            collider.enabled = false;
        }
    }
}
