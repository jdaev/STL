
namespace Base
{
    [System.Serializable]
    public class SpawnData
    {
        public string color;
        public float spawnAtProgressPercentage;
        public SpawnPosition position; 

        public SpawnData(string color, float spawnAtProgressPercentage, SpawnPosition position)
        {
            this.color = color;
            this.spawnAtProgressPercentage = spawnAtProgressPercentage;
            this.position = position;
        }
    }
    
}