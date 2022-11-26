// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Core.ECS.OneFrame
{
    public class COneFrameAuthoring : MonoBehaviour
    {
        [SerializeField] private int _framesActive = 2;

        public int FramesActive => _framesActive;
    }
}
