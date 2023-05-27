using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.GameFlow
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameOverCleanSystem))]
    public sealed class GameOverCleanSystem : CleanupSystem
    {
        private Filter _gameOverEventFilter;

        public override void OnAwake()
        {
            _gameOverEventFilter = World.Filter.With<GameOverEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _gameOverEventFilter)
            {
                World.RemoveEntity(entity);
            }
        }
    }
}