using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerMovementInputSystem))]
    public sealed class PlayerMovementInputSystem : SimpleUpdateSystem<MoveDirection, Player>
    {
        protected override void Process(Entity entity, ref MoveDirection moveDirection, ref Player player, in float deltaTime)
        {
            moveDirection.direction = Input.GetKeyDown(KeyCode.Space) ? Vector2.up : Vector2.zero;
        }
    }
}