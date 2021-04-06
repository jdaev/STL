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

    // public static readonly Dictionary<SpawnPosition, float> SpawnX = new Dictionary<SpawnPosition, float>()
    // {
    //     {SpawnPosition.FrontLeft, -10}, {SpawnPosition.FrontRight, 10}, {SpawnPosition.Center, 0},
    //     {SpawnPosition.SideLeft, -25}, {SpawnPosition.SideRight, 25},
    // };
    //
    // public static readonly Dictionary<SpawnPosition, float> SpawnY = new Dictionary<SpawnPosition, float>()
    // {
    //     {SpawnPosition.FrontLeft, 2}, {SpawnPosition.FrontRight, 2}, {SpawnPosition.Center, 4},
    //     {SpawnPosition.SideLeft, 6}, {SpawnPosition.SideRight, 6},
    // };
    //
    // public static readonly Dictionary<SpawnPosition, float> SpawnZ = new Dictionary<SpawnPosition, float>()
    // {
    //     {SpawnPosition.FrontLeft, 2}, {SpawnPosition.FrontRight, 2}, {SpawnPosition.Center, 0},
    //     {SpawnPosition.SideLeft, -10}, {SpawnPosition.SideRight, -10},
    // };
    
    public static readonly Dictionary<SpawnPosition, float> SpawnXStart = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, -10}, {SpawnPosition.FrontRight, 10}, {SpawnPosition.Center, -5},
        {SpawnPosition.SideLeft, -25}, {SpawnPosition.SideRight, 25},
    };
    
    public static readonly Dictionary<SpawnPosition, float> SpawnXEnd = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, -20}, {SpawnPosition.FrontRight, 20}, {SpawnPosition.Center, 5},
        {SpawnPosition.SideLeft, -25}, {SpawnPosition.SideRight, 25},
    };
    
    public static readonly Dictionary<SpawnPosition, float> SpawnYStart = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, 0}, {SpawnPosition.FrontRight, 0}, {SpawnPosition.Center, 10},
        {SpawnPosition.SideLeft, 10}, {SpawnPosition.SideRight, 10},
    };
    
    public static readonly Dictionary<SpawnPosition, float> SpawnYEnd = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, 10}, {SpawnPosition.FrontRight, 10}, {SpawnPosition.Center, 20},
        {SpawnPosition.SideLeft, 20}, {SpawnPosition.SideRight, 20},
    };

    public static readonly Dictionary<SpawnPosition, float> SpawnZStart = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, 0}, {SpawnPosition.FrontRight, 0}, {SpawnPosition.Center, 10},
        {SpawnPosition.SideLeft, 10}, {SpawnPosition.SideRight, 10},
    };
    
    public static readonly Dictionary<SpawnPosition, float> SpawnZEnd = new Dictionary<SpawnPosition, float>()
    {
        {SpawnPosition.FrontLeft, 0}, {SpawnPosition.FrontRight, 0}, {SpawnPosition.Center, 10},
        {SpawnPosition.SideLeft, 20}, {SpawnPosition.SideRight, 20},
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