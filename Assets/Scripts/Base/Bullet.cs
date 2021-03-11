﻿using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Base
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        private float _bulletSpeed = 10f;
        private float _range = 10f;
        private Vector3 _origin;
        private TrailRenderer _trail;
        
        public STLColor color;
        
        public virtual void Initialize()
        {
            transform.position = _origin;
            _trail = gameObject.GetComponent<TrailRenderer>();
        }

        public void Refresh()
        {
            transform.position += Vector3.forward * (_bulletSpeed * Time.deltaTime);
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
            _trail.Clear();
        }

        public GameObject GetGameObject => gameObject;
    }
}