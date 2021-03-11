using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class ObjectPool
    {
        private static ObjectPool _instance;

        public static ObjectPool Instance => _instance ??= new ObjectPool();

        private Transform _objectPoolParent;
        private Dictionary<string, Stack<IPoolable>> _pooledObjects = new Dictionary<string, Stack<IPoolable>>();

        private ObjectPool()
        {
            _objectPoolParent = new GameObject().transform;
            _objectPoolParent.name = "ObjectPool";
        }
    
        public void AddToPool(string objName, IPoolable poolable)
        {
            if (!_pooledObjects.ContainsKey(objName))
                _pooledObjects.Add(objName, new Stack<IPoolable>());
            _pooledObjects[objName].Push(poolable);
            poolable.GetGameObject.transform.SetParent(_objectPoolParent);
            poolable.GetGameObject.SetActive(false);
            poolable.Pooled(); 
        }

        public IPoolable RetrieveFromPool(string objectName)
        {
            if (_pooledObjects.ContainsKey(objectName) && _pooledObjects[objectName].Count > 0)
            {
                IPoolable toRet = _pooledObjects[objectName].Pop();
                toRet.GetGameObject.transform.SetParent(null);
                toRet.GetGameObject.SetActive(true);
                toRet.DePooled(); 
                return toRet;
            }
            return null;
        }
    }
}