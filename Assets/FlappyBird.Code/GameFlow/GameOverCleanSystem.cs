using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.GameFlow
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GameOverCleanSystem))]
    public sealed class GameOverCleanSystem : SimpleLateUpdateSystem<GameOverEvent>
    {
        protected override void Process(Entity entity, ref GameOverEvent component, in float deltaTime)
        {
            World.RemoveEntity(entity);
        }
    }
}