using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace FlappyBird.Code.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;

        private void Start()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            var entityProvider = GetComponent<EntityProvider>();
            ref var player = ref entityProvider.Entity.GetComponent<Player>();
            player.playerConfig = playerConfig;
            player.rigidbody = rigidbody;
        }
    }
}