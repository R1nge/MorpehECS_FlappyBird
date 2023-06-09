﻿using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace FlappyBird.Code.Sound
{
    public class ScoreIncreaseSoundProvider : MonoProvider<ScoreSound>
    {
    }

    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct ScoreSound : IComponent
    {
        public AudioSource scoreAudio;
    }
}