using System.Collections.Generic;
using Core.ECS.OneFrame;
using Initialization.WorldCreation;
using Unity.Entities;
using Update.Collision;
using Update.Damage;
using Update.Destroy;
using Update.FX.Listeners;
using Update.FX.SFX;
using Update.FX.VFX;
using Update.Input;
using Update.InputToMovementConverters.Alien;
using Update.InputToMovementConverters.Player;
using Update.Movement.Acceleration;
using Update.Movement.InstantTransformChanger;
using Update.Movement.Position;
using Update.Movement.Rotation;
using Update.Spawners.Aliens;
using Update.Spawners.Asteroids;
using Update.Spawners.Bullets;
using Update.Spawners.PowerUp;
using Update.Spawners.Unit;
using Update.Spawners.Unit.Initializers;
using Update.Weapons.Delay;

namespace Asteroids
{
    public class PRIORITY
    {
        private List<SystemBase> _systems = new List<SystemBase>();
        
        public PRIORITY()
        {
            _systems.Add(new SInitialPlayerSpawner());
            _systems.Add(new SAsteroidsSpawner());
            _systems.Add(new SAlienSpawner());
            
            _systems.Add(new SUnitSpawner());
            
            _systems.Add(new SPlayerInitializer());
            _systems.Add(new SAsteroidInitializer());
            _systems.Add(new SAliensInitializer());
            
            _systems.Add(null);
            
            _systems.Add(new SReadKeyboardInput());
            _systems.Add(new SApplyKeyboardMoveInput());
            _systems.Add(new SApplyKeyboardShootInput());
            
            _systems.Add(null);
            _systems.Add(new SApplyAlienAIToMovement());
            _systems.Add(null);
            
            _systems.Add(new SUpdateBulletDelay());
            _systems.Add(null);
            _systems.Add(new SBulletsSpawner());
            _systems.Add(new SBulletInitializer());
            
            _systems.Add(null);
            _systems.Add(new SShootingFXListener());
            
            _systems.Add(null);
            _systems.Add(new STransformInstantChanger());
            _systems.Add(null);
            _systems.Add(new SEntityMoveInDirection());
            _systems.Add(new SEngineAcceleration());
            _systems.Add(new SEntityRotateByAngle());
            
            _systems.Add(null);
            _systems.Add(new SEngineFXListener());
            _systems.Add(null);
            // _systems.Add(new SCollisionListener());
            _systems.Add(null);
            // _systems.Add(new SDamageCalculator());
            _systems.Add(null);
            // _systems.Add(new SDamageApplier());
            _systems.Add(null);
            _systems.Add(new SAsteroidDestroyFXListener());
            _systems.Add(new SShipExplosionFXListener());
            _systems.Add(null);
            _systems.Add(new SDeath());
            _systems.Add(null);
            _systems.Add(null);
            _systems.Add(new SPowerUpSpawner());
            _systems.Add(new SPowerUpInitializer());
            _systems.Add(null);
            _systems.Add(new SSFXPlayer());
            _systems.Add(new SVFXPlayer());
            _systems.Add(null);
            _systems.Add(new SRemoveOneFrameComponents());
            _systems.Add(null);
        }
    }
}