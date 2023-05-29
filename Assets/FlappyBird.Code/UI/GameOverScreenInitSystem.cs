using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Scellecs.Morpeh.Systems;
using TMPro;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.Code.UI
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(GameOverScreenInitSystem))]
    public class GameOverScreenInitSystem : Initializer
    {
        public GameObject gameOverScreen;
        public TextMeshProUGUI highScoreText;
        public Button restartButton;

        public override void OnAwake()
        {
            ref var screen = ref World.CreateEntity().AddOrGet<GameOverScreen>();
            screen.gameOverScreen = gameOverScreen;
            screen.highScoreText = highScoreText;
        }
    }
}