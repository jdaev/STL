using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Base
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        private float _bulletSpeed = 10f;
        private float _range = 100f;
        private Vector3 _origin = Vector3.zero;

        public STLColor color;

        public virtual void Initialize()
        {
            transform.position = _origin;
        }

        public void Refresh()
        {
            float distance = (_bulletSpeed * Time.deltaTime);
            transform.position += transform.forward * distance;
            CheckHit(distance);
            OnReachingRangeEnd();
        }

        void CheckHit(float distance)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance))
            {
                var enemy = hit.transform.gameObject.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.OnBulletHit(color);
                }

                BulletManager.Instance.RemoveBullet(this);
            }
        }

        void OnHitEnemy()
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