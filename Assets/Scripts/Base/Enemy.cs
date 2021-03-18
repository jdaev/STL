using System;
using System.Linq;
using Managers;
using UnityEngine;

namespace Base
{
    public class Enemy : MonoBehaviour, IPoolable
    {
        public ShootableColor color;

        private Animator _animator;
        private float speed = 10f;
        
        public void Initialize()
        {
            _animator = gameObject.GetComponent<Animator>();
        }
        bool AnimatorIsPlaying(){
            return _animator.GetCurrentAnimatorStateInfo(0).length >
                   _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }
        public void Refresh()
        {   
            if(!AnimatorIsPlaying())
                Move();
        }

        private void Move()
        {
            transform. position= Vector3.MoveTowards(transform.position,
                GameManager.Instance.PlayerManager.Player.transform.position, speed * Time.deltaTime);
        }

        public void OnBulletHit(STLColor bulletColor)
        {
            if (color.weaknesses.Contains(bulletColor))
            {
                gameObject.SetActive(false);
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

        public GameObject GetGameObject => gameObject;
    }
}