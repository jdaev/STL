using UnityEngine;

namespace Base
{
    public class Projectile : MonoBehaviour, IPoolable
    {

        public void Initialize()
        {
            
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