using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class BulletFactory
    {
        private static BulletFactory _instance;

        public static BulletFactory Instance => _instance ?? (_instance = new BulletFactory());

        private BulletFactory()
        {
        }

        private Dictionary<STLColor, GameObject> bulletPrefabDict;

        private string bulletPrefabPath = "Prefabs/Bullets/";


        public void Initialize()
        {
            bulletPrefabDict = new Dictionary<STLColor, GameObject>();
            GameObject[] allPrefabs = Resources.LoadAll<GameObject>(bulletPrefabPath);
            foreach (GameObject prefab in allPrefabs)
            {
                Bullet bullet = prefab.GetComponent<Bullet>();
                bulletPrefabDict.Add(bullet.color, prefab);
            }
        }

        public Bullet CreateBullet(STLColor color, Vector3 originPoint)
        {
            Bullet res;
            GameObject resObj;
            IPoolable poolable = ObjectPool.Instance.RetrieveFromPool(color.ToString());
            if (poolable != null)
            {
                resObj = poolable.GetGameObject;
                res = resObj.GetComponent<Bullet>();
            }
            else
            {
                res = _CreateBullet(color);
                resObj = res.gameObject;
            }

            resObj.transform.position = originPoint;

            return res;
        }

        private Bullet _CreateBullet(STLColor color)
        {
            if (!bulletPrefabDict.ContainsKey(color))
            {
                Debug.Log("Bullet Not Found");
                return null;
            }

            GameObject newBulletObj = GameObject.Instantiate(bulletPrefabDict[color]);
            Bullet newBullet = newBulletObj.GetComponent<Bullet>();
            newBullet.Initialize();
            return newBullet;
        }
    }
}