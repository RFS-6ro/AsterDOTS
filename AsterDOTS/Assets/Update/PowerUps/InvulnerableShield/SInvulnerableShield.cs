// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Damageable;
using Unity.Entities;
using Update.Damage;

namespace Update.PowerUps.InvulnerableShield
{
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [UpdateBefore(typeof(SDamageApplier))]
    public partial class SInvulnerableShield : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CDamageable>()
                .WithAll<CInvulnerableShield>()
                .ForEach((ref CDamage damage) =>
                {
                    damage.Amount = 0;
                })
                .Run();
        }
    }
}
