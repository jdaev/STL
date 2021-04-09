using System;

namespace Base
{
    [Serializable]
    public class Level
    {
        public float levelLength;
        public float playerSpeed;
        public string soundtrack;
        
        public SpawnData[] spawnPoints;
        public float spawnDistanceFromPlayer;

        public int spawnCountMin;
        public int spawnCountMax;
        
        public Level(float levelLength, float playerSpeed, string soundtrack, SpawnData[] spawnPoints, float spawnDistanceFromPlayer, int spawnCountMin, int spawnCountMax)
        {
            this.levelLength = levelLength;
            this.playerSpeed = playerSpeed;
            this.soundtrack = soundtrack;
            this.spawnPoints = spawnPoints;
            this.spawnDistanceFromPlayer = spawnDistanceFromPlayer;
            this.spawnCountMax = spawnCountMax;
            this.spawnCountMin = spawnCountMin;
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