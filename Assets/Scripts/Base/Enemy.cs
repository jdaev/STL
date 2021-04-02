using System;
using System.Linq;
using Managers;
using UnityEngine;

namespace Base
{
    public class Enemy : MonoBehaviour, IPoolable
    {
        public ShootableColor color;
        private readonly float _speed = 10f;
        private readonly float _turnAngle = 5f;
        private readonly float _minimumDistance = 20f;
        private bool _hasShot = false;
        private Player _player;

        public void Initialize()
        {
            _player = GameManager.Instance.PlayerManager.Player;
        }

        public void Refresh()
        {
            
            if (!_hasShot && Vector3.Angle(transform.position, _player.transform.position) < _turnAngle)
            {
                GameManager.Instance.ProjectileManager.ShootProjectile(transform);
                _hasShot = true;
            }
            else
            {
                LookAtPlayer();
            }

            if (Vector3.Distance(transform.position, _player.transform.position) > _minimumDistance)
            {
                MoveTowardsPlayer();
            }

            if (transform.position.z < _player.transform.position.z)
            {
                Kill();
            }
        }

        private void LookAtPlayer()
        {
            Transform target = GameManager.Instance.PlayerManager.Player.transform;
            Vector3 relativePos = target.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, _speed * Time.deltaTime);
        }

        private void MoveTowardsPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _player.transform.position, _speed * Time.deltaTime);
        }

        public void OnBulletHit(STLColor bulletColor)
        {
            if (color.weaknesses.Contains(bulletColor))
            {
                GameManager.Instance.AudioManager.PlayEnemyDeathSound();
                Kill();
            }
        }

        public void Kill()
        {
            GameManager.Instance.EnemyManager.RemoveEnemy(this);
        }

        public void Pooled()
        {
        }

        public void DePooled()
        {
        }
    }
}