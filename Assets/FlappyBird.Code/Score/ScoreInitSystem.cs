using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Score
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(ScoreInitSystem))]
    public sealed class ScoreInitSystem : Initializer
    {
        private Filter _scoreIncreaseEventFilter;

        public override void OnAwake()
        {
            _scoreIncreaseEventFilter = World.Filter.With<Score>();
            
            foreach (var scoreIncrease in _scoreIncreaseEventFilter)
            {
                World.RemoveEntity(scoreIncrease);
            }

            var score = World.CreateEntity();
            score.AddComponent<Score>();
        }
    }
}