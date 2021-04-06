using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using Random = UnityEngine.Random;

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


            var spawnZ = (levelLength * (spawnData.spawnAtProgressPercentage) / 100) + spawnDelay;
            int spawnCount = Random.Range(GameManager.Instance.Level.spawnCountMin,GameManager.Instance.Level.spawnCountMax);
            int spawned = 0;
            Vector3 spawnPoint = Vector3.zero;
            while (spawned < spawnCount)
            {
                spawnPoint = new Vector3(Random.Range(Values.SpawnXStart[spawnData.position],
                    Values.SpawnXEnd[spawnData.position]), Random.Range(Values.SpawnYStart[spawnData.position],
                    Values.SpawnYEnd[spawnData.position]), Random.Range(Values.SpawnZStart[spawnData.position] + spawnZ,
                    Values.SpawnZEnd[spawnData.position] + spawnZ));
                bool hasHit = Physics.CheckSphere(spawnPoint, 0.5f);
                if (!hasHit)
                {
                    GameObject spawner = new GameObject("EnemySpawner");
                    spawner.transform.SetParent(_spawnerParent.transform);
                    spawner.transform.position = spawnPoint;


                    var enemySpawner = spawner.AddComponent<EnemySpawner>();
                    enemySpawner.Initialize(spawnData);
                    _enemySpawners.Enqueue(enemySpawner);
                    spawned++;
                }
            }
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