// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.Utils;
using Initialization.Configs;
using Initialization.Configs.EventSystem;
using Unity.Entities;
using Unity.Mathematics;
using Update.Spawners.Unit;

namespace Initialization.WorldCreation
{
    [RequireMatchingQueriesForUpdate]
    public partial class SInitialPlayerSpawner : SystemBase
    {
        private bool _isInitialized = false;
        
        protected override void OnUpdate()
        {
            if (_isInitialized) { return; }
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(EntityManager.WorldUnmanaged);
            
            CUnitSpawnRequest request = 
                new SpawnRequestBuilder(1)
                    .AddUnit(EntityType.PlayerShip, new float3(1000f, 0f, 1000f))
                    .Build();
            
            CEventSystemConfig eventSystemConfig = SystemAPI.GetSingleton<CEventSystemConfig>();
            
            Entity entity = entityCommandBuffer.Instantiate(eventSystemConfig.EventPrefab);
            entityCommandBuffer.SetComponent(entity, new COneFrame { FramesActive = 1 });
            entityCommandBuffer.AddComponent(entity, request);

            _isInitialized = true;
        }
    }
}
