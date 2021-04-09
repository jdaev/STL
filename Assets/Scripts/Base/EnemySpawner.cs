using Managers;
using UnityEngine;

namespace Base
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _spawnAtProgress;
        private string _color;

        public bool CanSpawn => GameManager.Instance.PlayerProgress > _spawnAtProgress;

        public void Initialize(SpawnData spawnData)
        {
            _color = spawnData.color;
            _spawnAtProgress = spawnData.spawnAtProgressPercentage;
        }


        public void SpawnEnemy()
        {
            GameManager.Instance.EnemyManager.SpawnEnemy(Values.Values.ShootableColors[_color], transform);
        }
    }
}