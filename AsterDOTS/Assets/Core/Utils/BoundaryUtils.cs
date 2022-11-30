// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Core.ECS.Random;
using Initialization.Configs.Boundary;
using Initialization.Configs.SpawnPoints;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Update.Movement.InstantTransformChanger;

namespace Core.Utils
{
    public static class BoundaryUtils
    {
        public static CChangeTransformRequest GetSeamlessPosition(this CBoundaryConfig config, TransformAspect aspect)
        {
            float3 currentPosition = aspect.Position;
            float3 currentForward = aspect.Forward;

            bool byX = math.abs(currentForward.x) < math.abs(currentForward.z);

            float newX = currentPosition.x;
            float newZ = currentPosition.z;
            if (byX)
            {
                newX = currentPosition.x < config.Bounds.min.x
                        ? config.Bounds.max.x
                        : config.Bounds.min.x;
            }
            else
            {
                newZ = currentPosition.z < config.Bounds.min.z
                        ? config.Bounds.max.z
                        : config.Bounds.min.z;
            }
            
            return new CChangeTransformRequest
            {
                Position = new float3(newX, 0f, newZ),
                Rotation = aspect.Rotation
            };
        }
        
        public static (float3 position, float3 forward) GetRandomSpawnPoint(this CSpawnPointsConfig config, RefRW<CRandom> random)
        {
            int randomPoint = random.ValueRW.Random.NextInt(config.Count);
            return (config.Points[randomPoint], config.Forwards[randomPoint]);
        }

        public static float Aspect(this CBoundaryConfig config)
        {
            return config.X / (float) config.Y;
        }
    }
}
