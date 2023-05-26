using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementSystem))]
    public sealed class MovementSystem : SimpleUpdateSystem<Player, MoveDirection>
    {
        protected override void Process(Entity entity, ref Player player, ref MoveDirection moveDirection, in float deltaTime)
        {
            var direction = moveDirection.direction;

            if (direction != Vector2.zero)
            {
                player.rigidbody.AddForce(player.playerConfig.jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }
    }
}