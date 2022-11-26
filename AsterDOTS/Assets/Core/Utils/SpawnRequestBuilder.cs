// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Initialization.Configs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Services.Core;
using Update.Spawners.Unit;

namespace Core.Utils
{
    public enum BuilderOptions
    {
        Soft,
        Hard
    }
    
    public struct SpawnRequestBuilder
    {
        private CUnitSpawnRequest _request;
        private BuilderOptions _options;
        
        private int _addedUnits;
        
        public SpawnRequestBuilder(int count, BuilderOptions options = BuilderOptions.Hard)
        {
            _request = new CUnitSpawnRequest();
            _addedUnits = 0;
            _options = options;
            _ = SetCount(count);
        }

        public SpawnRequestBuilder SetCount(int count)
        {
            _request.Count = count;
            _request.Positions = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
            _request.Directions = new NativeArray<float3>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
            _request.UnitTypes = new NativeArray<EntityType>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
            return this;
        }

        public SpawnRequestBuilder AddUnit(EntityType type) => AddUnit(type, float3.zero, float3.zero);

        public SpawnRequestBuilder AddUnit(EntityType type, float3 position) => AddUnit(type, position, float3.zero);

        public SpawnRequestBuilder AddUnit(EntityType type, float3 position, float3 direction)
        {
            if (_addedUnits == _request.Count)
            {
                switch (_options)
                {
                    case BuilderOptions.Soft:
                        SpawnRequestBuilder builder = new SpawnRequestBuilder(_addedUnits + 1);
                        CopyTo(ref builder).AddUnit(type, position, direction);
                        return builder;
                    case BuilderOptions.Hard:
                        throw new ArgumentOutOfRangeException(nameof(_request.Count), $"SpawnRequestBuilder::AddUnit. Request size exceeded. Requests Count: {_request.Count}. Units added: {_addedUnits}");
                    default:
                        throw new NotImplementedException();
                }
            }

            _request.Positions[_addedUnits] = position;
            _request.Directions[_addedUnits] = direction;
            _request.UnitTypes[_addedUnits] = type;
            ++_addedUnits;
            
            return this;
        }

        public CUnitSpawnRequest Build()
        {
            if (_addedUnits != _request.Count)
            {
                switch (_options)
                {
                    case BuilderOptions.Soft:
                        SpawnRequestBuilder builder = new SpawnRequestBuilder(_addedUnits);
                        CopyTo(ref builder);
                        return builder.Build();
                    case BuilderOptions.Hard:
                        throw new ServicesInitializationException($"Requests Count: {_request.Count}. Units added: {_addedUnits}");
                    default:
                        throw new NotImplementedException();
                }
            }

            return _request;
        }

        public SpawnRequestBuilder CopyTo(ref SpawnRequestBuilder spawnRequestBuilder)
        {
            for (int i = 0; i < _addedUnits; i++)
            {
                spawnRequestBuilder.AddUnit
                (
                    position:   _request.Positions[i],
                    direction:  _request.Directions[i],
                    type:       _request.UnitTypes[i]
                );
            }
            return this;
        }
    }
}
