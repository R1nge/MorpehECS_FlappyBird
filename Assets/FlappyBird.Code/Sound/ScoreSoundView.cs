using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace FlappyBird.Code.Sound
{
    public class ScoreSoundView : MonoBehaviour
    {
        [SerializeField] private AudioSource scoreSource;

        private void Start()
        {
            var entityProvider = GetComponent<EntityProvider>();
            ref var scoreSound = ref entityProvider.Entity.GetComponent<ScoreSound>();
            scoreSound.scoreAudio = scoreSource;
        }
    }
}