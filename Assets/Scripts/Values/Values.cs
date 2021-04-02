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
        {"Red", new ShootableColor(STLColor.Red, new[] {STLColor.Blue, STLColor.Green})},
        {"Blue", new ShootableColor(STLColor.Blue, new[] {STLColor.Red, STLColor.Green})},
        {"Green", new ShootableColor(STLColor.Green, new[] {STLColor.Red, STLColor.Blue})},
    };

    public static readonly Dictionary<SpawnPosition, float> SpawnX = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, -5}, {SpawnPosition.FrontRight, 5}, {SpawnPosition.Center, 0},
        {SpawnPosition.SideLeft, -10}, {SpawnPosition.SideRight, 10},
    };

    public static readonly Dictionary<SpawnPosition, float> SpawnY = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, 0}, {SpawnPosition.FrontRight, 0}, {SpawnPosition.Center, 2},
        {SpawnPosition.SideLeft, 3}, {SpawnPosition.SideRight, 3},
    };

    public static readonly Dictionary<SpawnPosition, float> SpawnZ = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, 2}, {SpawnPosition.FrontRight, 2}, {SpawnPosition.Center, 0},
        {SpawnPosition.SideLeft, 0}, {SpawnPosition.SideRight, 0},
    };
}

[Serializable]
public enum SpawnPosition
{
    FrontLeft,
    FrontRight,
    Center,
    SideLeft,
    SideRight,
}


public enum GameTags
{
    Enemy,
    Prop,
}