
namespace Base
{
    [System.Serializable]
    public class SpawnData
    {
        public string color;
        public float spawnAtProgressPercentage;
        public string side; //"RIGHT" OR "LEFT"
        public int numberToSpawn;
        public int spawnIntervalInSeconds;

        public SpawnData(string color, float spawnAtProgressPercentage, string side, string height, int numberToSpawn, int spawnIntervalInSeconds)
        {
            this.color = color;
            this.spawnAtProgressPercentage = spawnAtProgressPercentage;
            this.side = side;
            this.numberToSpawn = numberToSpawn;
            this.spawnIntervalInSeconds = spawnIntervalInSeconds;
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