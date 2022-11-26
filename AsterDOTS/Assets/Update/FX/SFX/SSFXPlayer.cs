// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Update.Destroy;

namespace Update.FX.SFX
{
    [UpdateAfter(typeof(SDeath))]
    public partial class SSFXPlayer : SystemBase
    {
        protected override void OnUpdate()
        {
            
        }
    }
}
