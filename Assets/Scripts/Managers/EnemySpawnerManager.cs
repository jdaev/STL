using System.Collections;
using System.Collections.Generic;
using Base;

namespace Managers
{
    public class EnemySpawnerManager
    {
        private static EnemySpawnerManager _instance;

        public static EnemySpawnerManager Instance => _instance ??= new EnemySpawnerManager();
        private readonly Queue<EnemySpawner> _enemySpawners;
        

        private EnemySpawnerManager()
        {
        }

        public void Initialize()
        {
        }

        public void Refresh()
        {
            
        }
    }
}