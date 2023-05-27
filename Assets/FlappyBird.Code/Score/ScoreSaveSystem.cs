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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ScoreSaveSystem))]
    public sealed class ScoreSaveSystem : UpdateSystem
    {
        public GlobalEvent onGameOverEvent;
        private Filter _scoreFilter;
        private int _previousHighScore;

        public override void OnAwake()
        {
            _scoreFilter = World.Filter.With<Score>();
            _previousHighScore = PlayerPrefs.GetInt("HighScore", 0);
        }

        public override void OnUpdate(float deltaTime)
        {
            if (onGameOverEvent.IsPublished)
            {
                foreach (var entity in _scoreFilter)
                {
                    var currentScore = entity.GetComponent<Score>().points;
                    if (currentScore > _previousHighScore)
                    {
                        PlayerPrefs.SetInt("HighScore", currentScore);
                        PlayerPrefs.Save();
                    }
                }
            }
        }
    }
}