// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Update.Movement.Position
{
    public class CMoveDirectionAuthority : MonoBehaviour
    {
        [SerializeField] private Vector3 _vector;
        
        public float3 Vector => _vector;
    }
}
