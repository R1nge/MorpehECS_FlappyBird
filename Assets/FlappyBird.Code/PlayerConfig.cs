using UnityEngine;

namespace FlappyBird.Code
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float jumpForce;
    }
}