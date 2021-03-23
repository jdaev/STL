using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Base
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _spawnAtProgress;
        private string _color;
        
        public bool CanSpawn => GameManager.Instance.PlayerProgress > _spawnAtProgress;

        public void Initialize(SpawnData spawnData)
        {
            this._color = spawnData.color;
            this._spawnAtProgress = spawnData.spawnAtProgressPercentage;
        }

        

        public void SpawnEnemy()
        {
            GameManager.Instance.EnemyManager.SpawnEnemy(Values.ShootableColors[_color], transform
                );
        }
    }
}