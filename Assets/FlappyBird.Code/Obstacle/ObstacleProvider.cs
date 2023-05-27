using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Obstacle
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ObstacleProvider : MonoProvider<Obstacle>
    {
    }

    [Serializable]
    public struct Obstacle : IComponent
    {
        public ObstacleConfig obstacleConfig;
        public Transform transform;
    }
}