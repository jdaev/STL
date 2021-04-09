using Managers;
using UnityEngine;

namespace Base
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private float timeToReachPlayer = 1f;
        [SerializeField] private TrailRenderer trailRenderer;
        [SerializeField] private Rigidbody projectileRigidbody;
        
        public void Initialize()
        {
            float playerSpeed = GameManager.Instance.Level.playerSpeed;
            GameObject mainCamera = Camera.main.gameObject;
            Vector3 cameraPosition = mainCamera.transform.position;
            var projectilePosition = transform.position;
            Vector3 estimatedPlayerPosition = ((cameraPosition - projectilePosition) / timeToReachPlayer) +
                                              new Vector3(0, 0, playerSpeed);
            projectileRigidbody.velocity = estimatedPlayerPosition;
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
            trailRenderer.Clear();
        }

        public void DePooled()
        {
            projectileRigidbody.velocity = Vector3.zero;
            
        }
    }
}