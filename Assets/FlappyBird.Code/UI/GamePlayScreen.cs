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
    public struct GamePlayScreen : IComponent
    {
        public GamePlayScreen(GameObject gamePlayScreen, TextMeshProUGUI scoreText)
        {
            this.gamePlayScreen = gamePlayScreen;
            this.scoreText = scoreText;
        }

        public GameObject gamePlayScreen;
        public TextMeshProUGUI scoreText;
    }
}