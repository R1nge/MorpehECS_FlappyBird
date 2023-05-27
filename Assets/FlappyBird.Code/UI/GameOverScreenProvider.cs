using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using TMPro;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.UI
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class GameOverScreenProvider : MonoProvider<GameOverScreen>
    {
    }

    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct GameOverScreen : IComponent
    {
        public GameObject gameOverScreen;
        public TextMeshProUGUI scoreText;
    }
}