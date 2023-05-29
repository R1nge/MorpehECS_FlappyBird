using FlappyBird.Code.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;

namespace FlappyBird.Code.Player.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PlayerMovementInitSystem : Initializer
    {
        private Filter _playerWithoutMovement;

        public override void OnAwake()
        {
            _playerWithoutMovement = World.Filter.With<Player>().Without<MoveDirection>();
            foreach (var entity in _playerWithoutMovement)
            {
                entity.AddComponent<MoveDirection>();
            }
        }
    }
}