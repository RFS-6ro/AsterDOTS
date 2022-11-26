// ----------------------------------------------------------------------------
// The Proprietary or MIT License
// Copyright (c) 2022-2022 RFS_6ro <rfs6ro@gmail.com>
// ----------------------------------------------------------------------------

using Unity.Entities;

namespace Initialization.Configs.EntityMovement
{
    public class CEntityMoveConfigBaker : Baker<CEntityMoveConfigAuthoring>
    {
        public override void Bake(CEntityMoveConfigAuthoring auth)
        {
            AddComponent(new CEntityMoveConfig
            {
                PlayerShipSpeed = auth.PlayerShipSpeed,
                PlayerShipRotationSpeed = auth.PlayerShipRotationSpeed,
                PowerUpPlaceholderSpeed = auth.PowerUpPlaceholderSpeed,
            });
        }
    }
}
