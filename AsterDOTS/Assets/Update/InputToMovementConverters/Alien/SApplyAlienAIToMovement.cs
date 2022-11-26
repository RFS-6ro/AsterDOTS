// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;
using Update.InputToMovementConverters.Player;

namespace Update.InputToMovementConverters.Alien
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SApplyKeyboardShootInput))]
    public partial class SApplyAlienAIToMovement : SystemBase
    {
        protected override void OnUpdate()
        {
            
        }
    }
}
