using UnityEngine;

namespace FlappyBird.Code.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float jumpForce;
    }
}