using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird.Code.UI
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameOverScreenSystem))]
    public sealed class GameOverScreenSystem : UpdateSystem
    {
        public GlobalEvent onGameOverEvent;
        private Filter _gameOverScreenFilter;
        private bool _gameEnded;

        public override void OnAwake()
        {
            _gameOverScreenFilter = World.Filter.With<GameOverScreen>();
            foreach (var entity in _gameOverScreenFilter)
            {
                var screen = entity.GetComponent<GameOverScreen>();
                screen.restartButton.onClick.AddListener(() =>
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                });
            }
        }

        public override void OnUpdate(float deltaTime)
        {
            if (onGameOverEvent.IsPublished)
            {
                foreach (var entity in _gameOverScreenFilter)
                {
                    var gameOverScreen = entity.GetComponent<GameOverScreen>();
                    gameOverScreen.gameOverScreen.SetActive(true);
                    gameOverScreen.highScoreText.text = $"High score: {PlayerPrefs.GetInt("HighScore", 0)}";
                }
            }
        }
    }
}