using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Base
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private int spawnInterval;
        [SerializeField] private int numberOfEnemiesToSpawn = 1;
        [SerializeField] private SpawnPosition spawnPosition;
        [SerializeField] private float spawnAtProgress;
        public STLColor color;

        private float _secondsElapsed = 0;
        private int enemySpawnCount = 0;
        public void Initialize()
        {
        }

        public void Update()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            if (_secondsElapsed >= spawnInterval && enemySpawnCount<numberOfEnemiesToSpawn)
            {
                if (GameManager.Instance.LevelManager.PlayerProgress> spawnAtProgress)
                {
                    GameManager.Instance.EnemyManager.SpawnEnemy(Values.ShootableColors[color.ToString()], transform,
                        spawnPosition);
                    enemySpawnCount++;
                }

                _secondsElapsed = 0;
            }
            else
                _secondsElapsed += Time.deltaTime;
        }

        
    }
}