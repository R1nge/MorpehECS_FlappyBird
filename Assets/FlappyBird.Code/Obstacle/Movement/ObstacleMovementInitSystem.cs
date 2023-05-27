using FlappyBird.Code.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Obstacle.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(ObstacleMovementInitSystem))]
    public sealed class ObstacleMovementInitSystem : Initializer
    {
        private Filter _obstacleWithoutMovement;

        public override void OnAwake()
        {
            _obstacleWithoutMovement = World.Filter.With<Obstacle>().Without<MoveDirection>();
            foreach (var entity in _obstacleWithoutMovement)
            {
                entity.AddComponent<MoveDirection>();
            }
        }
    }
}