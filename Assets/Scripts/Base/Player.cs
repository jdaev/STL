using Managers;
using UnityEngine;

namespace Base
{
    public class Player : MonoBehaviour
    {
        public int HitCount { get; private set; } = 0;
        private bool _isDead = false;

        public void Initialize()
        {
            _isDead = false;
            transform.position.Set(0, GameManager.Instance.PlayerHeight, 0);
        }

        public void Refresh()
        {
            Move();
        }

        public void Kill()
        {
            if (!_isDead)
            {
                _isDead = true;
                Time.timeScale = 0;
                ControllerManager.Instance.ToggleInteractors(true);
                GameManager.Instance.GameAudioSource.Stop();
                UIManager.Instance.OnGameOver();
            }
        }

        public void OnEnemyHit()
        {
            //Kill();
            HitCount++;
        }


        private void Move()
        {
            if (transform.position.z < GameManager.Instance.Level.levelLength)
            {
                transform.Translate(transform.forward * (GameManager.Instance.Level.playerSpeed * Time.deltaTime));
            }
            else
            {
                UIManager.Instance.OnVictory();
            }
        }
    }
}