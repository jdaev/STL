using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class ProjectileFactory
    {
        public ProjectileFactory()
        {
        }

        private GameObject _projectilePrefab;

        private string projectilePrefabPath = "Prefabs/Projectiles/Projectile";


        public void Initialize()
        {
            
                _projectilePrefab = Resources.Load<GameObject>(projectilePrefabPath);
            
        }

        public Projectile CreateProjectile(Transform originPoint)
        {
            Projectile res;
            GameObject resObj;
            IPoolable poolable = ObjectPool.Instance.RetrieveFromPool("Projectile");
            if (poolable != null )
            {
                resObj = poolable.gameObject;
                res = resObj.GetComponent<Projectile>();
            }
            else
            {
                res = _CreateProjectile();
                resObj = res.gameObject;
            }

            resObj.transform.position = originPoint.position;
            //resObj.transform.rotation = originPoint.rotation;
            
            res.Initialize();
            return res;
        }

        private Projectile _CreateProjectile()
        {
           

            GameObject newProjectileObj = Object.Instantiate(_projectilePrefab);
            Projectile newProjectile = newProjectileObj.GetComponent<Projectile>();
            return newProjectile;
        }
    }
}