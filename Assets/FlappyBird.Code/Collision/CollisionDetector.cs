using Scellecs.Morpeh;
using UnityEngine;

namespace FlappyBird.Code.Collision
{
    public class CollisionDetector : MonoBehaviour
    {
        public Collider2D[] colliders;
        public Entity listener;
        private World _world;

        public void Init(World world)
        {
            _world = world;
        }

        private void OnEnable()
        {
            colliders = GetComponentsInChildren<Collider2D>();
#if DEBUG
            if (colliders.Length <= 0)
            {
                throw new($"There are no any Colliders to handle collisions on {name}");
            }
#endif
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
#if DEBUG
            if (listener == null || !listener.Has<CanCollide>())
            {
                throw new($"{nameof(listener)} should have {nameof(CanCollide)}");
            }
#endif

            var eventEntity = _world.CreateEntity();
            ref var collisionEvent = ref eventEntity.AddComponent<CollisionEvent>();
            collisionEvent.collision = other;
            collisionEvent.first = listener;
            var otherDetector = other.gameObject.GetComponent<CollisionDetector>();
            collisionEvent.second = otherDetector != null ? otherDetector.listener : null;
        }
    }
}