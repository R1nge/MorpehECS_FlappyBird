using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyBird.Code.UI
{
    public class GameOverScreenView : MonoBehaviour
    {
        [SerializeField] public GameObject gameOverScreen;
        [SerializeField] public TextMeshProUGUI highScoreText;
        [SerializeField] public Button restartButton;

        private void Start()
        {
            restartButton.onClick.AddListener(() =>
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            });
            var entityProvider = GetComponent<EntityProvider>();
            ref var screen = ref entityProvider.Entity.GetComponent<GameOverScreen>();
            screen.gameOverScreen = gameOverScreen;
            screen.highScoreText = highScoreText;
        }
    }
}