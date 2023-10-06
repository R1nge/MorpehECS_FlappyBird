using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Score
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ScoreSystem))]
    public sealed class ScoreSystem : UpdateSystem
    {
        public GlobalEventInt scoreIncreaseEvent;
        private Filter _scoreIncreaseScoreEventFilter;
        private Filter _scoreFilter;

        public override void OnAwake()
        {
            _scoreIncreaseScoreEventFilter = World.Filter.With<ScoreIncreaseEvent>();
            _scoreFilter = World.Filter.With<Score>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var scoreIncrease in _scoreIncreaseScoreEventFilter)
            {
                foreach (var score in _scoreFilter)
                {
                    ref var points = ref score.GetComponent<Score>().points;
                    points++;
                    scoreIncreaseEvent.Publish(points);
                }
            }
        }
    }
}