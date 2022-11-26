// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Asteroid;
using Unity.Entities;
using Update.Destroy;
using Update.FX.Containers;

namespace Update.FX.Listeners
{
    [UpdateBefore(typeof(SDeath))]
    public partial class SAsteroidDestroyFXListener : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CAsteroid>()
                .WithAll<CDeathEvent>()
                .ForEach((CVFXContainer vfx, CSFXContainer sfx) =>
                {
                    //Send Asteroid Destroy FX Events
                })
                .Run();
        }
    }
}
