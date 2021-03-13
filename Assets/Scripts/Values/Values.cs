using System;
using System.Collections.Generic;
using Base;
using UnityEngine;


    public static class Values
    {
        public static readonly Dictionary<STLColor, Color> ColorMap = new Dictionary<STLColor, Color>()
        {
            {STLColor.Red, Color.red},
            {STLColor.Blue, Color.blue},
            {STLColor.Green, Color.green},
        };
        
        public static readonly Dictionary<String, ShootableColor> ShootableColors = new Dictionary<String, ShootableColor>()
        {
            {"Red", new ShootableColor(STLColor.Red,new []{STLColor.Blue,STLColor.Green})},
            {"Blue", new ShootableColor(STLColor.Blue,new []{STLColor.Red,STLColor.Green})},
            {"Green", new ShootableColor(STLColor.Green,new []{STLColor.Red,STLColor.Blue})},
        };


        
    }

public enum GameTags
{
    Enemy,
    Prop,
    
}
