using Managers;
using UnityEngine;

namespace Base
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private float timeToReachPlayer = 5f;
        private Rigidbody _rigidbody;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            float playerSpeed = GameManager.Instance.Level.playerSpeed;
            GameObject mainCamera = Camera.main.gameObject;
            Vector3 cameraPosition = mainCamera.transform.position;
            var projectilePosition = transform.position;
            Vector3 estimatedPlayerPosition = ((cameraPosition - projectilePosition) / timeToReachPlayer) +
                                              new Vector3(0, 0, playerSpeed);
            _rigidbody.velocity = estimatedPlayerPosition;
        }

        public void Refresh()
        {
        }

        private void OnCollisionEnter(Collision other)
        {
            //This collider is attached to the main camera, i,e; The player head
            //Easier to get this tag than to get the player layer.
            if (other.gameObject.CompareTag("MainCamera"))
            {
                GameManager.Instance.PlayerManager.Player.OnEnemyHit();
                GameManager.Instance.ProjectileManager.RemoveProjectile(this);
            }
        }

        public void Pooled()
        {
        }

        public void DePooled()
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}