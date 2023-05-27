using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.UI
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GamePlayScreenSystem))]
    public sealed class GamePlayScreenSystem : UpdateSystem
    {
        public GlobalEventInt scoreIncreaseEvent;
        private Filter _gamePlayScreenFilter;

        public override void OnAwake()
        {
            _gamePlayScreenFilter = World.Filter.With<GamePlayScreen>();
        }

        public override void OnUpdate(float deltaTime)
        {
            if (scoreIncreaseEvent.IsPublished)
            {
                foreach (var gameplayScreen in _gamePlayScreenFilter)
                {
                    var screen = gameplayScreen.GetComponent<GamePlayScreen>();
                    screen.scoreText.text = scoreIncreaseEvent.BatchedChanges.Pop().ToString();
                }
            }
        }
    }
}