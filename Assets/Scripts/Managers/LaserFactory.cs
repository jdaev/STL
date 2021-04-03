using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class LaserFactory
    {
        private Dictionary<STLColor, GameObject> _laserPrefabDict;

        private string laserPrefabPath = "Prefabs/Lasers/";


        public void Initialize()
        {
            _laserPrefabDict = new Dictionary<STLColor, GameObject>();
            GameObject[] allPrefabs = Resources.LoadAll<GameObject>(laserPrefabPath);
            foreach (GameObject prefab in allPrefabs)
            {
                Laser laser = prefab.GetComponent<Laser>();
                _laserPrefabDict.Add(laser.color, prefab);
            }
        }

        public Laser CreateLaser(STLColor color, Transform origin, Vector3 destination)
        {
            Laser res;
            GameObject resObj;
            IPoolable poolable = ObjectPool.Instance.RetrieveFromPool("Laser:" + color);
            if (poolable != null)
            {
                resObj = poolable.gameObject;
                res = resObj.GetComponent<Laser>();
            }
            else
            {
                res = _CreateLaser(color);
                resObj = res.gameObject;
            }
            
            res.Initialize(origin,destination);

            return res;
        }

        private Laser _CreateLaser(STLColor color)
        {
            if (!_laserPrefabDict.ContainsKey(color))
            {
                Debug.Log("Laser Not Found");
                return null;
            }

            GameObject newLaserObj = GameObject.Instantiate(_laserPrefabDict[color]);
            Laser newLaser = newLaserObj.GetComponent<Laser>();
            return newLaser;
        }
    }
}