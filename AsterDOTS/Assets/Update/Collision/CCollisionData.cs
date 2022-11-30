using Initialization.Configs;
using Unity.Entities;

namespace Update.Collision
{
    public struct EntityData
    {
        public Entity Entity;
        public EntityType Type;
    }
    
    public struct CCollisionData : IComponentData
    {
        public EntityData A;
        public EntityData B;

        public bool Processed;
    }
}
