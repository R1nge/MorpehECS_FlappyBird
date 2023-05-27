using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.GameFlow
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameOverSystem))]
    public sealed class GameOverSystem : SimpleLateUpdateSystem<GameOverEvent>
    {
        private Filter _gameOverEventFilter;

        protected override void Process(Entity entity, ref GameOverEvent gameOver, in float deltaTime)
        {
            _gameOverEventFilter = World.Filter.With<GameOverEvent>();
            foreach (var gameOverEntity in _gameOverEventFilter)
            {
                //TODO: show UI
                Debug.Log("Gameover");
                World.RemoveEntity(gameOverEntity);
                Time.timeScale = 0;
            }
        }
    }
}