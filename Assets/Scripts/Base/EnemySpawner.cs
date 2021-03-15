using UnityEngine;

namespace Base
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private SpawnData _spawnData;

        private float _secondsElapsed = 0;
        
        public void Initialize()
        {
            
        }

        public void Refresh()
        {
            if (_secondsElapsed >= _spawnData.SpawnInterval)
            {
                SpawnEnemy();
                _secondsElapsed += Time.deltaTime;
            }
        }

        public void SpawnEnemy()
        {
            
        }

        public void AnimateToSpawn()
        {
            
        }
        
        
    }
}