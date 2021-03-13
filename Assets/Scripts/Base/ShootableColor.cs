using System;
using UnityEngine.Serialization;

namespace Base
{
    public enum STLColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Magenta,
    }

    [Serializable]
    public class ShootableColor
    {
        public STLColor color;
        public STLColor[] weaknesses;

        public ShootableColor(STLColor color, STLColor[] weaknesses)
        {
            this.color = color;
            this.weaknesses = weaknesses;
        }
    }
}