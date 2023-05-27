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
        private Filter _increaseScoreEventFilter;

        public override void OnAwake()
        {
            _increaseScoreEventFilter = World.Filter.With<IncreaseScoreEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _increaseScoreEventFilter)
            {
                World.RemoveEntity(entity);
            }
        }
    }
}