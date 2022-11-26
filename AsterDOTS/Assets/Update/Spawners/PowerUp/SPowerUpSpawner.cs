// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Update.Destroy;

namespace Update.Spawners.PowerUp
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SDeath))]
    public partial class SPowerUpSpawner : SystemBase
    {
        protected override void OnUpdate()
        {
        }
    }
}
