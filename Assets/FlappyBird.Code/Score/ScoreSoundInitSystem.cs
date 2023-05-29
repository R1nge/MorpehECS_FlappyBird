using FlappyBird.Code.Sound;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Score
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(ScoreSoundInitSystem))]
    public class ScoreSoundInitSystem : Initializer
    {
        public AudioSource audioSource;

        public override void OnAwake()
        {
            World.CreateEntity().AddComponent<ScoreSound>().scoreAudio = audioSource;
        }
    }
}