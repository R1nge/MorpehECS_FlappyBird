using System;
using Scellecs.Morpeh;
using TMPro;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.UI
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct GameOverScreen : IComponent
    {
        public GameObject gameOverScreen;
        public TextMeshProUGUI highScoreText;
    }
}