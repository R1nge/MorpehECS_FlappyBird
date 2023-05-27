using FlappyBird.Code.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Obstacle.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ObstacleMovementSystem))]
    public sealed class ObstacleMovementSystem : SimpleUpdateSystem<Obstacle, MoveDirection>
    {
        protected override void Process(Entity entity, ref Obstacle obstacle, ref MoveDirection moveDirection, in float deltaTime)
        {
            moveDirection.direction = Vector2.left;
            var moveVector3 = new Vector3(moveDirection.direction.x * obstacle.obstacleConfig.moveSpeed, 0, 0);
            obstacle.transform.position += moveVector3 * deltaTime;

            if (obstacle.transform.position.x <= -3.5f)
            {
                obstacle.transform.position = new(3.5f, Random.Range(-3.5f, 3.5f), obstacle.transform.position.z);
            }
        }
    }
}