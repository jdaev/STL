using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Base
{
    public class EnemySpawner : MonoBehaviour
    {
        
        [SerializeField] private int spawnInterval;
        [SerializeField] private SpawnPosition spawnPosition;
        
        public STLColor color;

        private float _secondsElapsed = 0;
        
        public void Initialize()
        {
            
        }

        public void Update()
        {
            if (_secondsElapsed >= spawnInterval)
            {
                SpawnEnemy();
                _secondsElapsed = 0;
            }
            else
                _secondsElapsed += Time.deltaTime;
        }

        private void SpawnEnemy()
        {
            GameManager.Instance.EnemyManager.SpawnEnemy(Values.ShootableColors[color.ToString()],transform);
        }

        public void AnimateToSpawn()
        {
            
        }
        
        
    }
}