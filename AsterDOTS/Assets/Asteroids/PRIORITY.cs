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
using Update.PowerUps.InvulnerableShield;
using Update.PowerUps.Shooting.BulletSpeedChange;
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
        public PRIORITY()
        {
            /*
             SInitialPlayerSpawner
             SAsteroidsSpawner
             SAlienSpawner
             SUnitSpawner
             SPlayerInitializer
             SAsteroidInitializer
             
             SAliensInitializer
             SReadKeyboardInput
             SApplyKeyboardMoveInput
             SApplyKeyboardShootInput
             SApplyAlienAIToMovement
             SApplyAlienAIToShoot
             SBulletShootingDelayChange
             SUpdateBulletDelay
             SBulletsSpawner 
             
             SBulletInitializer
             SShootingFXListener SBulletSpeedChangeApply STransformInstantChanger
             SEntityMoveInDirection
             SEntityRotateByAngle SEngineAcceleration
             
             SEngineFXListener
             
             SCollisionListener
             SReadCollisionData
             SProcessBoundaryCollisions
             SProcessPowerUpsPickUp
             SProcessDamageAfterCollision
             
             SDamageApplier
             SPowerUpSpawner
             SPowerUpInitializer
             SInvulnerableShield
             
             SEntityRotateByAngle
             SCreatingSmallerAsteroidPartsOnDeathEvent
             SAsteroidDestroyFXListener SShipExplosionFXListener
             SDeath
             SSFXPlayer SVFXPlayer SRemoveOneFrameComponents
             */
        }
    }
}