using FlappyBird.Code.Collision;
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
    public sealed class ObstacleHitSystem : SimpleLateUpdateSystem<CollisionEvent>
    {
        protected override void Process(Entity entity, ref CollisionEvent collisionEvent, in float deltaTime)
        {
            var obstacleEntity = collisionEvent.first;
            obstacleEntity.GetComponent<Obstacle>(out var isObstacle);
        }
    }
}