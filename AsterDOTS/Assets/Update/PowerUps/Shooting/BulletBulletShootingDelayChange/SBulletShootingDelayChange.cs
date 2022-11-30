// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Weapon;
using Unity.Entities;
using Update.InputToMovementConverters.Alien;
using Update.Weapons.Stats;

namespace Update.PowerUps.Shooting.BulletBulletShootingDelayChange
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SApplyAlienAIToShoot))]
    public partial class SBulletShootingDelayChange : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithAll<CWeapon>()
                .ForEach((CBulletShootingDelayChange change, ref CWeaponStats stats) =>
                {
                    stats.ShotDelay *= change.Multiplier;
                })
                .Run();
        }
    }
}
