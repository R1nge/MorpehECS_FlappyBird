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
    public sealed class GamePlayScreenProvider : MonoProvider<GamePlayScreen>
    {
    }

    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct GamePlayScreen : IComponent
    {
        public GameObject gamePlayScreen;
        public TextMeshProUGUI scoreText;
    }
}