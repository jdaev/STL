using System;
using System.Collections;
using System.Linq;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Base
{
    public class Enemy : MonoBehaviour, IPoolable
    {
        public ShootableColor color;
        private readonly float _speed = 4f;
        private readonly float _minimumDistance = 20f;
        private readonly float _waitTime = 5f;
        private bool _hasShot = false;
        private bool _isWaiting = true;
        private Player _player;
        private Camera _camera;

        public void Initialize()
        {
            _player = GameManager.Instance.PlayerManager.Player;
            _camera = Camera.main;
        }

        public void Refresh()
        {
            if (Vector3.SqrMagnitude(transform.position - _player.transform.position) > Math.Pow(_minimumDistance, 2))
            {
                MoveTowardsPlayer();
            }
            else
            {
                if (!_hasShot)
                {
                    GameManager.Instance.ProjectileManager.ShootProjectile(transform);
                    _hasShot = true;
                }
                else
                {
                    if (_isWaiting)
                        StartCoroutine(Smash());
                    else
                        MoveTowardsPlayer();
                }
            }


            LookAtPlayer();
        }


        IEnumerator Smash()
        {
            yield return new WaitForSeconds(_waitTime);
            _isWaiting = false;
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
                _camera.transform.position, _speed * Time.deltaTime);
        }


        public void OnBulletHit(STLColor bulletColor)
        {
            if (!color.weaknesses.Contains(bulletColor)) return;
            GameManager.Instance.AudioManager.PlayEnemyDeathSound();
            Kill();
        }

        private void OnPlayerHit()
        {
            GameManager.Instance.AudioManager.PlayEnemyDeathSound();
            GameManager.Instance.EnemyManager.RemoveEnemy(this);
            _player.OnEnemyHit();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("MainCamera")) return;
            OnPlayerHit();
        }

        private void Kill()
        {
            GameManager.Instance.EnemyManager.KillEnemy(this);
        }

        public void Pooled()
        {
        }

        public void DePooled()
        {
            _hasShot = false;
        }
    }
}