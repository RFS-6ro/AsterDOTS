// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.OneFrame;
using Core.ECS.Random;
using Core.ECS.Tags.Initialize;
using Core.Utils;
using Initialization.Configs;
using Initialization.Configs.EntityPrefabs;
using Unity.Entities;
using Unity.Mathematics;
using Update.Movement.InstantTransformChanger;
using Update.Movement.Position;
using Update.Spawners.Aliens;
using Update.Spawners.Unit.Initializers;

namespace Update.Spawners.Unit
{
    [RequireMatchingQueriesForUpdate]
    [UpdateAfter(typeof(SAlienSpawner))]
    public partial class SUnitSpawner : SystemBase
    {
        protected override void OnUpdate()
        {
            RefRW<CRandom> random = SystemAPI.GetSingletonRW<CRandom>();
            CEntityPrefabsConfig prefabsConfig = SystemAPI.GetSingleton<CEntityPrefabsConfig>();
            
            EntityCommandBuffer entityCommandBuffer = SystemAPI
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);

            Entities
                .WithAll<COneFrame>()
                .ForEach((CUnitSpawnRequest request) =>
                {
                    for (int i = 0; i < request.Count; i++)
                    {
                        EntityType type = request.UnitTypes[i];
                        float3 position = request.Positions[i];
                        float3 direction = request.Directions[i];
                        
                        Entity unit = entityCommandBuffer.Instantiate(prefabsConfig.GetEntityPrefab(type));

                        float3 moveDirection = !direction.Equals(float3.zero)
                            ? direction
                            : new float3
                            (
                                random.ValueRW.Random.NextFloat(-1, 1),
                                0,
                                random.ValueRW.Random.NextFloat(-1, 1)
                            );
                        
                        entityCommandBuffer.AddComponent(unit, new CMoveDirection
                        {
                            Vector = moveDirection
                        });
                        
                        entityCommandBuffer.AddComponent(unit, new CChangeTransformRequest()
                        {
                            Position = position,
                            Rotation = quaternion.LookRotation(moveDirection, DirectionUtils.Up())
                        });
                        
                        entityCommandBuffer.AddComponent(unit, new CNeedInitialize());
                        entityCommandBuffer.AddComponent(unit, new CUnitInitializationData()
                        {
                            UnitType = type
                        });
                    }
                })
                .Run();
        }
    }
}