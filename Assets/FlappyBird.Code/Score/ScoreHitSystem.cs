using FlappyBird.Code.Collision;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Score
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ScoreHitSystem))]
    public sealed class ScoreHitSystem : SimpleUpdateSystem<TriggerEvent>
    {
        protected override void Process(Entity entity, ref TriggerEvent triggerEvent, in float deltaTime)
        {
            var obstacleEntity = triggerEvent.first;
            obstacleEntity.GetComponent<Obstacle.Obstacle>(out var isObstacle);
            if (!isObstacle)
            {
                return;
            }

            triggerEvent.second.GetComponent<Player.Player>();
            World.CreateEntity().AddComponent<IncreaseScoreEvent>();
        }
    }
}