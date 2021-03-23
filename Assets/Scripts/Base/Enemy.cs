using System;
using System.Linq;
using Managers;
using UnityEngine;

namespace Base
{
    public class Enemy : MonoBehaviour, IPoolable
    {
        public ShootableColor color;
        private float speed = 10f;

        public void Initialize()
        {
        }
        // bool AnimatorIsPlaying(){
        //     return _animator.GetCurrentAnimatorStateInfo(0).length >
        //            _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        // }
        public void Refresh()
        {   
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            Transform target = GameManager.Instance.PlayerManager.Player.transform;
            Vector3 relativePos = target.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            transform.rotation =  Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }
        
        private void Move()
        {
            transform.position= Vector3.MoveTowards(transform.position,
                GameManager.Instance.PlayerManager.Player.transform.position, speed * Time.deltaTime);
        }

        public void OnBulletHit(STLColor bulletColor)
        {
            if (color.weaknesses.Contains(bulletColor))
            {
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