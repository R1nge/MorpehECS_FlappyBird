using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Score
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ScoreEventCleanSystem))]
    public sealed class ScoreEventCleanSystem : CleanupSystem
    {
        private Filter _scoreIncreaseEventFilter;

        public override void OnAwake()
        {
            _scoreIncreaseEventFilter = World.Filter.With<ScoreIncreaseEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var scoreIncrease in _scoreIncreaseEventFilter)
            {
                World.RemoveEntity(scoreIncrease);
            }
        }
    }
}