using System;
using System.Linq;
using UnityEngine;

namespace Base
{
    public class Enemy : MonoBehaviour
    {
        public ShootableColor color;

        public void Start()
        {
            Material material = gameObject.GetComponent<MeshRenderer>().material;
            material.color = Values.ColorMap[color.color];
        }

        public void OnBulletHit(STLColor bulletColor)
        {
            if (color.weaknesses.Contains(bulletColor))
            {
                gameObject.SetActive(false);
            }
        }
        
    }
}
