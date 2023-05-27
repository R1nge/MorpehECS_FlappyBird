using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Collision
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(CollisionInitSystem))]
    public sealed class CollisionInitSystem : Initializer
    {
        private Filter _players;
        private Filter _obstacles;

        public override void OnAwake()
        {
            _players = World.Filter.With<Player.Player>().Without<CanCollide>();
            _obstacles = World.Filter.With<Obstacle.Obstacle>().Without<CanCollide>();
            ProcessPlayers();
            ProcessObstacles();
        }

        private void ProcessPlayers()
        {
            foreach (var entity in _players)
            {
                ref var player = ref entity.GetComponent<Player.Player>();
                MakeCanCollide(entity, player.rigidbody.gameObject);
            }
        }

        private void ProcessObstacles()
        {
            foreach (var entity in _obstacles)
            {
                ref var obstacle = ref entity.GetComponent<Obstacle.Obstacle>();
                MakeCanCollide(entity, obstacle.transform.gameObject);
            }
        }

        private void MakeCanCollide(Entity entity, GameObject gameObject)
        {
            ref var canCollide = ref entity.AddComponent<CanCollide>();
            canCollide.collisionDetector = gameObject.AddComponent<CollisionDetector>();
            canCollide.collisionDetector.Init(World);
            canCollide.collisionDetector.listener = entity;
        }
    }
}