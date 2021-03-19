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
        
        public Level(float levelLength, float playerSpeed, string soundtrack, SpawnData[] spawnPoints)
        {
            this.levelLength = levelLength;
            this.playerSpeed = playerSpeed;
            this.soundtrack = soundtrack;
            this.spawnPoints = spawnPoints;
        }
    }
}