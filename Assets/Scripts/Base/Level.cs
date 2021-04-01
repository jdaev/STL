using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Base
{
    [System.Serializable]
    public class Level
    {
        public float levelLength;
        public float playerSpeed;
        public string soundtrack;
        
        public SpawnData[] spawnPoints;
        public float spawnDistanceFromPlayer;
        public Level(float levelLength, float playerSpeed, string soundtrack, SpawnData[] spawnPoints, float spawnDistanceFromPlayer)
        {
            this.levelLength = levelLength;
            this.playerSpeed = playerSpeed;
            this.soundtrack = soundtrack;
            this.spawnPoints = spawnPoints;
            this.spawnDistanceFromPlayer = spawnDistanceFromPlayer;
        }
    }
    [Serializable]
    public class LevelNames
    {
        public string[] levels;

        public LevelNames(string[] levels)
        {
            this.levels = levels;
        }
    }
}