using System.Collections;
using Managers;
using UnityEngine;

namespace Base
{
    public class Laser : MonoBehaviour, IPoolable
    {
        private LineRenderer _lineRenderer;
        private float lifetime = 0.15f;

        private Transform _origin;
        private Vector3 _destination;
        
        public STLColor color;


        public virtual void Initialize(Transform origin, Vector3 destination)
        {
            if (_lineRenderer == null)
            {
                _lineRenderer = GetComponent<LineRenderer>();
            }

            _origin = origin;
            _destination = destination;
            
            transform.SetParent(_origin);
            
            transform.position = _origin.position;
            transform.rotation = _origin.rotation;


            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _destination);

            StartCoroutine(Destroy());
        }

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(lifetime);

            GameManager.Instance.LaserManager.RemoveLaser(this);
        }

        public void Refresh()
        {
            //transform.Translate(transform.forward * (GameManager.Instance.Level.playerSpeed * Time.deltaTime));
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