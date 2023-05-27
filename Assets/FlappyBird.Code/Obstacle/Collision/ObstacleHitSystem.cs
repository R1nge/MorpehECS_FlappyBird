using FlappyBird.Code.Collision;
using FlappyBird.Code.GameFlow;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Obstacle.Collision
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ObstacleHitSystem))]
    public sealed class ObstacleHitSystem : SimpleUpdateSystem<CollisionEvent>
    {
        protected override void Process(Entity entity, ref CollisionEvent collisionEvent, in float deltaTime)
        {
            var obstacleEntity = collisionEvent.first;
            obstacleEntity.GetComponent<Obstacle>(out var isObstacle);
            if (!isObstacle)
            {
                return;
            }

            collisionEvent.second.GetComponent<Player.Player>();
            World.CreateEntity().AddComponent<GameOverEvent>();
        }
    }
}