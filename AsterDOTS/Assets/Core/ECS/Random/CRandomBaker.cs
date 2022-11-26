// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Core.ECS.Random
{
    public class CRandomBaker : Baker<CRandomAuthoring>
    {
        public override void Bake(CRandomAuthoring auth)
        {
            AddComponent(new CRandom
            {
                Random = new Unity.Mathematics.Random(auth.Seed)
            });
        }
    }
}
