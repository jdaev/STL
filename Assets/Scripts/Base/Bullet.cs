using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Base
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        private float _bulletSpeed = 10f;
        private float _range = 100f;
        
        private Vector3 _origin;
        private Vector3 _destination;
        public STLColor color;
        
        public virtual void Initialize()
        {
            transform.position = _origin;
        }

        public void Refresh()
        {
            transform.position += transform.forward * (_bulletSpeed * Time.deltaTime);
            OnHitTarget();
            OnReachingRangeEnd();
        }

        
        void OnHitTarget()
        {
        }

        void OnReachingRangeEnd()
        {
        
            if (Vector3.SqrMagnitude(_origin - transform.position) > Mathf.Pow(_range, 2))
            {
                BulletManager.Instance.RemoveBullet(this);
            }
        }

        public void OnFired()
        {
        }

        public void Pooled()
        {
        }

        public void DePooled()
        {
        }

        public GameObject GetGameObject => gameObject;
    }
}