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
            createSpawnerParent();
            _enemySpawners = new Queue<EnemySpawner>();
        }

        private void createSpawnerParent()
        {
            
                _spawnerParent = new GameObject();
            
        }

        public void AddEnemySpawner(SpawnData spawnData, float levelLength, float spawnDelay)
        {
            if(_spawnerParent==null) createSpawnerParent();
            GameObject spawner = new GameObject("EnemySpawner");
            spawner.transform.SetParent(_spawnerParent.transform);
            EnemySpawner enemySpawner;
            var position = spawner.transform.position;
            var playerHeight = GameManager.Instance.PlayerHeight;
            var spawnZ = (levelLength * (spawnData.spawnAtProgressPercentage) / 100) + spawnDelay;
            switch (spawnData.position)
            {
                case SpawnPosition.Center:
                    spawner.transform.position =
                        new Vector3(0, playerHeight + 2, spawnZ);
                    break;
                case SpawnPosition.FrontLeft:
                    spawner.transform.position =
                        new Vector3(-3, playerHeight, spawnZ + 2);

                    break;
                case SpawnPosition.FrontRight:
                    spawner.transform.position =
                        new Vector3(3, playerHeight, spawnZ + 2);

                    break;
                case SpawnPosition.SideLeft:
                    spawner.transform.position =
                        new Vector3(-6, playerHeight, spawnZ);
                    break;
                case SpawnPosition.SideRight:
                    spawner.transform.position =
                        new Vector3(6, playerHeight, spawnZ);

                    break;
            }

            enemySpawner = spawner.AddComponent<EnemySpawner>();
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