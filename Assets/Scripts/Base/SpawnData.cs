
namespace Base
{
    [System.Serializable]
    public class SpawnData
    {
        public string color;
        public float spawnAtProgressPercentage;
        public string side; //"RIGHT" OR "LEFT"

        public SpawnData(string color, float spawnAtProgressPercentage, string side)
        {
            this.color = color;
            this.spawnAtProgressPercentage = spawnAtProgressPercentage;
            this.side = side;
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