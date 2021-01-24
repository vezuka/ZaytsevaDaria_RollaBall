using System;
using UnityEngine;

namespace RollaBall
{
    public sealed class CaughtPlayerEventArgs : EventArgs
    {
        public Color Color { get; }

        public CaughtPlayerEventArgs(Color color)
        {
            Color = color;
        }
    }
}


