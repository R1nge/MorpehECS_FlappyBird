using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using TMPro;
using UnityEngine;

namespace FlappyBird.Code.UI
{
    public class GamePlayScreenView : MonoBehaviour
    {
        [SerializeField] public GameObject gamePlayScreen;
        [SerializeField] public TextMeshProUGUI scoreText;

        private void Start()
        {
            var entityProvider = GetComponent<EntityProvider>();
            ref var screen = ref entityProvider.Entity.GetComponent<GamePlayScreen>();
            screen.gamePlayScreen = gamePlayScreen;
            screen.scoreText = scoreText;
        }
    }
}