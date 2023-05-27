using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Collision
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionCleanSystem))]
    public sealed class CollisionCleanSystem : CleanupSystem
    {
        private Filter _collisionFilter;
        private Filter _triggerFilter;

        public override void OnAwake()
        {
            _collisionFilter = World.Filter.With<CollisionEvent>();
            _triggerFilter = World.Filter.With<TriggerEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _collisionFilter)
            {
                entity.RemoveComponent<CollisionEvent>();
                World.RemoveEntity(entity);
            }

            foreach (var entity in _triggerFilter)
            {
                entity.RemoveComponent<TriggerEvent>();
                World.RemoveEntity(entity);
            }
        }
    }
}