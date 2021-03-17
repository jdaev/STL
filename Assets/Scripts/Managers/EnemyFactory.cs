using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class EnemyFactory
    {
        public EnemyFactory()
        {
        }

        private Dictionary<STLColor, GameObject> _enemyPrefabDict;

        private string enemyPrefabPath = "Prefabs/Enemies/";


        public void Initialize()
        {
            _enemyPrefabDict = new Dictionary<STLColor, GameObject>();
            GameObject[] allPrefabs = Resources.LoadAll<GameObject>(enemyPrefabPath);
            foreach (GameObject prefab in allPrefabs)
            {
                Enemy enemy = prefab.GetComponent<Enemy>();
                _enemyPrefabDict.Add(enemy.color.color, prefab);
            }
        }

        public Enemy CreateEnemy(ShootableColor color, Transform originPoint)
        {
            Enemy res;
            GameObject resObj;
            IPoolable poolable = ObjectPool.Instance.RetrieveFromPool(color.ToString());
            if (poolable != null)
            {
                resObj = poolable.GetGameObject;
                res = resObj.GetComponent<Enemy>();
            }
            else
            {
                res = _CreateEnemy(color);
                resObj = res.gameObject;
            }

            resObj.transform.position = originPoint.position;
            resObj.transform.rotation = originPoint.rotation;
            return res;
        }

        private Enemy _CreateEnemy(ShootableColor color)
        {
            if (!_enemyPrefabDict.ContainsKey(color.color))
            {
                Debug.Log("Enemy Not Found");
                return null;
            }

            GameObject newEnemyObj = GameObject.Instantiate(_enemyPrefabDict[color.color]);
            Enemy newEnemy = newEnemyObj.GetComponent<Enemy>();
            newEnemy.Initialize();
            return newEnemy;
        }
    }
}