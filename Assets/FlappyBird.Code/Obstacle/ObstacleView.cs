using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace FlappyBird.Code.Obstacle
{
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField] private ObstacleConfig obstacleConfig;

        private void Start()
        {
            var entityProvider = GetComponent<EntityProvider>();
            ref var obstacle = ref entityProvider.Entity.GetComponent<Obstacle>();
            obstacle.obstacleConfig = obstacleConfig;
            obstacle.transform = transform;
        }
    }
}