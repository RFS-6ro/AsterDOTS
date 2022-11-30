// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Random;
using Core.ECS.Tags.InputListener;
using Core.ECS.Tags.Weapon;
using Unity.Entities;
using Update.Spawners.Bullets;

namespace Update.InputToMovementConverters.Alien
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SApplyAlienAIToMovement))]
    public partial class SApplyAlienAIToShoot : SystemBase
    {
        protected override void OnUpdate()
        {
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            
            Entities
                .WithAll<CWeapon>()
                .WithNone<CInputListener>()
                .ForEach((ref CBulletShotRequest request) =>
                {
                    if (random.ValueRW.Random.NextFloat() < 0.1f 
                        && !request.IsActive 
                        && !request.InProgress)
                    {
                        request.IsActive = true;
                    }
                })
                .Run();
        }
    }
}
