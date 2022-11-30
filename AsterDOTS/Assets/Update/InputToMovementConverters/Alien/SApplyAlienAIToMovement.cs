// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Random;
using Core.ECS.Tags.AlienShip;
using Core.ECS.Tags.Ship;
using Unity.Entities;
using Unity.Transforms;
using Update.InputToMovementConverters.Player;
using Update.Movement.Position;
using Update.Movement.Rotation;

namespace Update.InputToMovementConverters.Alien
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SApplyKeyboardShootInput))]
    public partial class SApplyAlienAIToMovement : SystemBase
    {
        protected override void OnUpdate()
        {
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            
            Entities
                .WithAll<CAlienShip>()
                .WithAll<CShip>()
                .ForEach((TransformAspect aspect, ref CMoveDirection moveDirection, ref CRotation rotation) =>
                {
                    if (random.ValueRW.Random.NextFloat() < 0.1f)
                    {
                        moveDirection.Vector = aspect.Forward;
                    }

                    if (random.ValueRW.Random.NextFloat() < 0.05f)
                    {
                        rotation.Angle = random.ValueRW.Random.NextFloat(-1f, 1f);
                    }
                })
                .Run();
        }
    }
}
