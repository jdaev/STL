using System;
using System.Linq;
using UnityEngine;

namespace Base
{
    public class Enemy : MonoBehaviour, IPoolable
    {
        public ShootableColor color;

        public void Initialize()
        {
            Material material = gameObject.GetComponent<MeshRenderer>().material;
            material.color = Values.ColorMap[color.color];
        }

        public void Refresh()
        {
            
        }
        
        public void OnBulletHit(STLColor bulletColor)
        {
            if (color.weaknesses.Contains(bulletColor))
            {
                gameObject.SetActive(false);
            }
        }

        public void Pooled()
        {
            throw new NotImplementedException();
        }

        public void DePooled()
        {
            throw new NotImplementedException();
        }

        public GameObject GetGameObject { get; }
    }
}
