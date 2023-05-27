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

        public override void OnAwake()
        {
            _gameOverScreenFilter = World.Filter.With<GameOverScreen>();
        }

        public override void OnUpdate(float deltaTime)
        {
            if (onGameOverEvent.IsPublished)
            {
                foreach (var entity in _gameOverScreenFilter)
                {
                    entity.GetComponent<GameOverScreen>().gameOverScreen.SetActive(true);
                    //Time.timeScale = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}