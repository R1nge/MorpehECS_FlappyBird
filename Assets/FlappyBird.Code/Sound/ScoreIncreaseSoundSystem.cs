using FlappyBird.Code.Score;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Sound
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ScoreIncreaseSoundSystem))]
    public sealed class ScoreIncreaseSoundSystem : UpdateSystem
    {
        private Filter _scoreIncreaseEventFilter;
        private Filter _scoreSoundFilter;

        public override void OnAwake()
        {
            _scoreIncreaseEventFilter = World.Filter.With<ScoreIncreaseEvent>();
            _scoreSoundFilter = World.Filter.With<ScoreSound>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var increaseEvent in _scoreIncreaseEventFilter)
            {
                foreach (var sound in _scoreSoundFilter)
                {
                    sound.GetComponent<ScoreSound>().scoreAudio.Play();
                }
            }
        }
    }
}