// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Tags.Weapon;
using Core.Utils;
using Initialization.Configs.EventSystem;
using Unity.Entities;
using Unity.Transforms;
using Update.InputToMovementConverters.Player;
using Update.Spawners.Unit;
using Update.Weapons.Delay;

namespace Update.Spawners.Bullets
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SApplyKeyboardShootInput))]
    public partial class SBulletsSpawner : SystemBase
    {
        protected override void OnUpdate()
        {
            CEventSystemConfig eventSystemConfig = SystemAPI.GetSingleton<CEventSystemConfig>();

            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);

            Entities
                .WithAll<CWeapon>()
                .WithNone<CBulletShotDelay>()
                .ForEach((Entity entity, TransformAspect aspect, ref CBulletShotRequest bulletShotRequest) =>
                {
                    if (!bulletShotRequest.IsActive || bulletShotRequest.InProgress) { return; }

                    bulletShotRequest.InProgress = true;
                    
                    CUnitSpawnRequest request = 
                        new SpawnRequestBuilder(1)
                        .AddUnit(bulletShotRequest.Type, aspect.Position, aspect.Forward)
                        .Build();

                    Entity eventEntity = entityCommandBuffer.Instantiate(eventSystemConfig.EventPrefab);
                    
                    entityCommandBuffer.SetComponent(eventEntity, new COneFrame { FramesActive = 1 });
                    entityCommandBuffer.AddComponent(eventEntity, request);
                    
                    entityCommandBuffer.AddComponent(entity, new CBulletShotDelay()
                    {
                        LastShotTime = SystemAPI.Time.ElapsedTime
                    });
                })
                .Run();
        }
    }
}
