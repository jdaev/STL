using UnityEngine;

namespace Base
{
    public interface IPoolable
    {
        void Pooled();
        void DePooled();
        GameObject gameObject { get ; }     }
}