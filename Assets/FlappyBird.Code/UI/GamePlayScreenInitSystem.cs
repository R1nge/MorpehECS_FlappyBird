using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.UI
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(GamePlayScreenInitSystem))]
    public class GamePlayScreenInitSystem : Initializer
    {
        // public GameObject gamePlayScreen;
        // public TextMeshProUGUI scoreText;
        // public override void OnAwake()
        // {
        //     ref var screen = ref World.CreateEntity().AddOrGet<GamePlayScreen>();
        //     screen.gamePlayScreen = gamePlayScreen;
        //     screen.scoreText = scoreText;
        // }
        public override void OnAwake()
        {
        }
    }
}