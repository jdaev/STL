using System.Collections;
using Managers;
using UnityEngine;

namespace Base
{
    public class Laser : MonoBehaviour, IPoolable
    {
        [SerializeField] private LineRenderer lineRenderer;

        private float lifetime = 0.15f;

        private Transform _origin;
        private Vector3 _destination;

        public STLColor color;


        public virtual void Initialize(Transform origin, Vector3 destination)
        {
            _origin = origin;
            _destination = destination;

            transform.SetParent(_origin);

            transform.position = _origin.position;
            transform.rotation = _origin.rotation;


            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, _destination);

            StartCoroutine(Destroy());
        }

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(lifetime);

            GameManager.Instance.LaserManager.RemoveLaser(this);
        }

        public void Refresh()
        {
        }


        public void Pooled()
        {
        }

        public void DePooled()
        {
        }
    }
}