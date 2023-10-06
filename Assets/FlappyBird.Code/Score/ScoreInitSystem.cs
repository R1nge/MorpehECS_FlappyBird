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
        private Filter _increaseScoreEventFilter;

        public override void OnAwake()
        {
            _increaseScoreEventFilter = World.Filter.With<Score>();
            
            foreach (var entity in _increaseScoreEventFilter)
            {
                World.RemoveEntity(entity);
            }

            var score = World.CreateEntity();
            score.AddComponent<Score>();
        }
    }
}