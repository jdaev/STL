using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class ProjectileManager
    {
        private readonly HashSet<Projectile> _projectileHashSet;
        private readonly Stack<Projectile> _projectilesToRemoveStack;
        private readonly Stack<Projectile> _projectilesToAddStack;


        public ProjectileManager()
        {
            _projectileHashSet = new HashSet<Projectile>();
            _projectilesToRemoveStack = new Stack<Projectile>();
            _projectilesToAddStack = new Stack<Projectile>();
        }

        public void Initialize()
        {
        }

        public void Refresh()
        {
            while (_projectilesToRemoveStack.Count > 0)
            {
                Projectile toRemove = _projectilesToRemoveStack.Pop();
                if (!_projectileHashSet.Contains(toRemove))
                {
                    Debug.LogError("Stack tried to remove element of type: " + toRemove.ToString() +
                                   " but was not found in hashset?");
                }
                else
                {
                    _projectileHashSet.Remove(toRemove);
                    ObjectPool.Instance.AddToPool("Projectile", toRemove);
                    
                }
            }


            //Add Projectiles to the dictionary from the "toAdd stack"
            while (_projectilesToAddStack.Count > 0)
            {
                Projectile toAdd = _projectilesToAddStack.Pop();

                if (!_projectileHashSet.Contains(toAdd))
                {
                    _projectileHashSet.Add(toAdd);
                }
                else
                {
                    //Spotting an error where the same projectile is being initialized twice is almost impossible sometimes
                    Debug.LogError("The projectile you are trying to add is already in the projectile dict");
                }
            }


            foreach (Projectile b in _projectileHashSet)
                b.Refresh();
        }

        public void SpawnProjectile(ShootableColor type, Transform originPoint, SpawnPosition spawnPosition)
        {
            Projectile projectile = GameManager.Instance.ProjectileFactory.CreateProjectile(originPoint);
            AddProjectile(projectile);
        }

        private void AddProjectile(Projectile toAdd)
        {
            _projectilesToAddStack.Push(toAdd);
        }

        public void RemoveProjectile(Projectile toRemove)
        {
            _projectilesToRemoveStack.Push(toRemove);
        }
    }
}