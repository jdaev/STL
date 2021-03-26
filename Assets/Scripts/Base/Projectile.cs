using System.Runtime.InteropServices;
using Managers;
using UnityEngine;

namespace Base
{
    public class Projectile : MonoBehaviour, IPoolable
    {

        [SerializeField] private float timeToReachPlayer = 5f;
        [HideInInspector]
        public Vector3 destination;
        private Rigidbody _rigidbody;
        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Player player = GameManager.Instance.PlayerManager.Player;
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
        
        public void Pooled()
        {
            throw new System.NotImplementedException();
        }

        public void DePooled()
        {
            throw new System.NotImplementedException();
        }

        
        

        
    }
}