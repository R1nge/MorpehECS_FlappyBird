using UnityEngine;

namespace FlappyBird.Code.Obstacle
{
    [CreateAssetMenu(fileName = "ObstacleConfig", menuName = "ObstacleConfig")]
    public class ObstacleConfig : ScriptableObject
    {
        public float moveSpeed;
    }
}