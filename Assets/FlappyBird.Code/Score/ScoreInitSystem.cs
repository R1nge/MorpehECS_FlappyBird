using Scellecs.Morpeh;
using Scellecs.Morpeh.Helpers;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Score
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(ScoreInitSystem))]
    public class ScoreInitSystem : Initializer
    {
        public override void OnAwake()
        {
            World.CreateEntity().AddOrGet<Score>();
        }
    }
}