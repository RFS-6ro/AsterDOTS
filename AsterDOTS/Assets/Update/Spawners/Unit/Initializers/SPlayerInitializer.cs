// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Tags.Initialize;
using Core.ECS.Tags.Player;
using Initialization.Configs.EntityMovement;
using Initialization.Configs.PlayerMovement;
using Unity.Entities;
using Unity.Mathematics;
using Update.Movement.Position;
using Update.Movement.Rotation;

namespace Update.Spawners.Unit.Initializers
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SUnitSpawner))]
    public partial class SPlayerInitializer : SystemBase
    {
        protected override void OnUpdate()
        {
            CEntityMoveConfig entityMoveConfig = SystemAPI.GetSingleton<CEntityMoveConfig>();
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            Entities
                .WithAll<CPlayer>()
                .WithAll<CNeedInitialize>()
                .ForEach((Entity entity) =>
                {
                    entityCommandBuffer.AddComponent(entity, new CEntitySpeed
                    {
                        SpeedMultiplier = entityMoveConfig.PlayerShipSpeed,
                        RotationMultiplier = entityMoveConfig.PlayerShipRotationSpeed
                    });
                    
                    entityCommandBuffer.SetComponent(entity, new CMoveDirection
                    {
                        Vector = float3.zero
                    });
                    
                    entityCommandBuffer.AddComponent(entity, new CRotation());
                    
                    entityCommandBuffer.RemoveComponent<CNeedInitialize>(entity);
                    entityCommandBuffer.AddComponent(entity, new CInitialized());
                })
                .Run();
        }
    }
}
