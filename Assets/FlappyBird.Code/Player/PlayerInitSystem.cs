using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Player
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(PlayerInitSystem))]
    public class PlayerInitSystem : Initializer
    {
        public PlayerConfig playerConfig;
        public Rigidbody2D rigidbody;

        public override void OnAwake()
        {
            ref var player = ref World.CreateEntity().AddComponent<Player>();
            player.playerConfig = playerConfig;
            player.rigidbody = rigidbody;
        }
    }
}