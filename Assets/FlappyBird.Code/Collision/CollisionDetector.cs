using Scellecs.Morpeh;
using UnityEngine;

namespace FlappyBird.Code.Collision
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionDetector : MonoBehaviour
    {
        public Entity listener;
        private World _world;

        public void Init(World world)
        {
            _world = world;
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