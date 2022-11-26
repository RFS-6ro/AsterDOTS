// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Ship;
using Unity.Entities;
using Update.Destroy;
using Update.FX.Containers;

namespace Update.FX.Listeners
{
    [UpdateBefore(typeof(SDeath))]
    public partial class SShipExplosionFXListener : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CShip>()
                .WithAll<CDeathEvent>()
                .ForEach((CVFXContainer vfx, CSFXContainer sfx) =>
                {
                    //Send Ship destroy FX Events
                })
                .Run();
        }
    }
}
