// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace Initialization.Configs.SpawnPoints
{
    public class CSpawnPointsConfigAuthority : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        public IEnumerable<float3> Points => _points.Select((p) => (float3)p.position);
        public IEnumerable<float3> Forwards => _points.Select((p) => (float3)p.forward);
    }
}
