using System.Collections.Generic;
using Base;
using UnityEngine;


    public static class Values
    {
        public static Dictionary<STLColor, Color> colorMap = new Dictionary<STLColor, Color>()
        {
            {STLColor.Red, Color.red},
            {STLColor.Blue, Color.blue},
            {STLColor.Green, Color.green},
        };
    }
