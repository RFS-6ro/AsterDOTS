// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Update.Spawners.PowerUp;

namespace Update.Spawners.Unit.Initializers
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SPowerUpSpawner))]
    public partial class SPowerUpInitializer : SystemBase
    {
        protected override void OnUpdate()
        {
            
        }
    }
}
