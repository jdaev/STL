using System;
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
            CreateSpawnerParent();
            _enemySpawners = new Queue<EnemySpawner>();
        }

        private void CreateSpawnerParent()
        {
            _spawnerParent = new GameObject();
        }

        public void AddEnemySpawner(SpawnData spawnData, float levelLength, float spawnDelay)
        {
            if (_spawnerParent == null) CreateSpawnerParent();
            GameObject spawner = new GameObject("EnemySpawner");
            spawner.transform.SetParent(_spawnerParent.transform);
            var position = spawner.transform.position;
            var playerHeight = GameManager.Instance.PlayerHeight;
            var spawnZ = (levelLength * (spawnData.spawnAtProgressPercentage) / 100) + spawnDelay;

            spawner.transform.position = new Vector3(Values.SpawnX[spawnData.position],
                playerHeight + Values.SpawnY[spawnData.position], spawnZ + Values.SpawnZ[spawnData.position]);


            var enemySpawner = spawner.AddComponent<EnemySpawner>();
            enemySpawner.Initialize(spawnData);
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