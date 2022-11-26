// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Tags.Asteroid
{
    public class CAsteroidBaker : Baker<CAsteroidAuthority>
    {
        public override void Bake(CAsteroidAuthority auth)
        {
            AddComponent(new CAsteroid());
        }
    }
}
