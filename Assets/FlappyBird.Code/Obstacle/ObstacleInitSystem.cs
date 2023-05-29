using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Obstacle
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(ObstacleInitSystem))]
    public class ObstacleInitSystem : Initializer
    {
        public ObstacleConfig obstacleConfig;
        public Transform transform;

        public override void OnAwake()
        {
            ref var obstacle = ref World.CreateEntity().AddComponent<Obstacle>();
            obstacle.obstacleConfig = obstacleConfig;
            obstacle.transform = transform;
        }
    }
}