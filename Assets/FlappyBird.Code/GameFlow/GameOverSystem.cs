using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.GameFlow
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameOverSystem))]
    public sealed class GameOverSystem : UpdateSystem
    {
        public GlobalEvent onGameOverEvent;
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<GameOverEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                onGameOverEvent.Publish();
                Time.timeScale = 0;
            }
        }
    }
}