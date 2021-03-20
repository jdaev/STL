using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class EnemyManager
    {
        private readonly Dictionary<ShootableColor, List<Enemy>> _enemyDict;
        private readonly Stack<Enemy> _enemysToRemoveStack;
        private readonly Stack<Enemy> _enemysToAddStack;

        public int EnemiesKilled { get; private set; }

        public EnemyManager()
        {
            _enemyDict = new Dictionary<ShootableColor, List<Enemy>>();
            _enemysToRemoveStack = new Stack<Enemy>();
            _enemysToAddStack = new Stack<Enemy>();
        }

        public void Initialize()
        {
        }

        public void Refresh()
        {
            while (_enemysToRemoveStack.Count > 0)
            {
                Enemy toRemove = _enemysToRemoveStack.Pop();
                ShootableColor color = toRemove.color;
                if (!_enemyDict.ContainsKey(color) || !_enemyDict[color].Contains(toRemove))
                {
                    Debug.LogError("Stack tried to remove element of type: " + color.ToString() +
                                   " but was not found in dictionary?");
                }
                else
                {
                    _enemyDict[color].Remove(toRemove);
                    ObjectPool.Instance.AddToPool(color.color.ToString(), toRemove);
                    if (_enemyDict[color].Count == 0)
                        _enemyDict.Remove(color);
                }
            }


            //Add Enemys to the dictionary from the "toAdd stack"
            while (_enemysToAddStack.Count > 0)
            {
                Enemy toAdd = _enemysToAddStack.Pop();
                ShootableColor color = toAdd.color;

                if (!_enemyDict.ContainsKey(color)) // || !enemyDict[kv.Key].Contains(kv.Value))
                {
                    _enemyDict.Add(color, new List<Enemy>() {toAdd});
                }
                else if (!_enemyDict[color].Contains(toAdd))
                {
                    _enemyDict[color].Add(toAdd);
                }
                else
                {
                    //Spotting an error where the same enemy is being initialized twice is almost impossible sometimes
                    Debug.LogError("The enemy you are trying to add is already in the enemy dict");
                }
            }


            foreach (KeyValuePair<ShootableColor, List<Enemy>> kv in _enemyDict)
            foreach (Enemy b in kv.Value)
                b.Refresh();
        }

        public void SpawnEnemy(ShootableColor type, Transform originPoint, SpawnPosition spawnPosition)
        {
            Enemy enemy = GameManager.Instance.EnemyFactory.CreateEnemy(type, originPoint, spawnPosition);
            AddEnemy(enemy);
        }

        private void AddEnemy(Enemy toAdd)
        {
            _enemysToAddStack.Push(toAdd);
        }

        public void RemoveEnemy(Enemy toRemove)
        {
            EnemiesKilled++;
            _enemysToRemoveStack.Push(toRemove);
        }
    }
}