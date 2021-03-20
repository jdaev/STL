using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class EnemySpawnerManager
    {
        private readonly Queue<EnemySpawner> _enemySpawners;
        private GameObject _spawnerParent;
        public EnemySpawnerManager()
        {
            _spawnerParent = new GameObject();
            _enemySpawners = new Queue<EnemySpawner>();
        }

        public void AddEnemySpawner(SpawnData spawnData, float levelLength, float spawnDelay)
        {
            GameObject spawner = new GameObject("EnemySpawner");
            spawner.transform.SetParent(_spawnerParent.transform);
            EnemySpawner enemySpawner;
            
            if (spawnData.side == Values.SpawnPositions.Left.ToString())
            {
                spawner.transform.position =
                    new Vector3(-6, GameManager.Instance.PlayerHeight, ((levelLength * (spawnData.spawnAtProgressPercentage) / 100)+spawnDelay));
                enemySpawner = spawner.AddComponent<EnemySpawner>();
                enemySpawner.Initialize(spawnData, SpawnPosition.AroundLeft);
            }
            else
            {
                spawner.transform.position =
                    new Vector3(6, GameManager.Instance.PlayerHeight, ((levelLength * (spawnData.spawnAtProgressPercentage) / 100)+spawnDelay));
                enemySpawner = spawner.AddComponent<EnemySpawner>();
                enemySpawner.Initialize(spawnData, SpawnPosition.AroundRight);
            }

            _enemySpawners.Enqueue(enemySpawner);
        }


        public void Initialize()
        {
            _enemySpawners.Clear();
        }

        public void Refresh()
        {
            if (_enemySpawners.Count > 0)
            {
                if (_enemySpawners.Peek().CanSpawn)
                    _enemySpawners.Dequeue().SpawnEnemy();
            }
        }
    }
}