// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Update.FX.Containers;
using Update.Spawners.Bullets;
using Update.Spawners.Unit.Initializers;

namespace Update.FX.Listeners
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SBulletInitializer))]
    public partial class SShootingFXListener : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CBulletShotRequest>()
                .ForEach((CVFXContainer vfx, CSFXContainer sfx, CBulletShotRequest request) =>
                {
                    if (request.IsActive)
                    {
                        //Send shot FX Events
                    }
                })
                .Run();
        }
    }
}
