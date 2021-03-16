using System;

namespace Base
{
    [Serializable]
    public class SpawnData
    {
        public ShootableColor Color;
        public int SpawnInterval;
        public SpawnPosition SpawnPosition;

        public SpawnData(ShootableColor color, int spawnInterval, SpawnPosition spawnPosition)
        {
            Color = color;
            SpawnInterval = spawnInterval;
            SpawnPosition = spawnPosition;
        }
    }

    public enum SpawnPosition
    {
        UpTop,
        DownLow,
        AroundLeft,
        AroundRight,
    }
}