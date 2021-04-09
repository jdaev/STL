using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class LaserManager
    {
        private readonly Dictionary<STLColor, List<Laser>> _laserDict;
        private readonly Stack<Laser> _lasersToRemoveStack;
        private readonly Stack<Laser> _lasersToAddStack;


        public LaserManager()
        {
            _laserDict = new Dictionary<STLColor, List<Laser>>();
            _lasersToRemoveStack = new Stack<Laser>();
            _lasersToAddStack = new Stack<Laser>();
        }

        public void Initialize()
        {
            _laserDict.Clear();
            _lasersToAddStack.Clear();
            _lasersToRemoveStack.Clear();
        }

        public void Refresh()
        {
            while (_lasersToRemoveStack.Count > 0)
            {
                Laser toRemove = _lasersToRemoveStack.Pop();
                STLColor color = toRemove.color;
                if (!_laserDict.ContainsKey(color) || !_laserDict[color].Contains(toRemove))
                {
                    Debug.LogError("Stack tried to remove element of type: " + color +
                                   " but was not found in dictionary?");
                }
                else
                {
                    _laserDict[color].Remove(toRemove);
                    ObjectPool.Instance.AddToPool("Laser:" + color, toRemove);
                    if (_laserDict[color].Count == 0)
                        _laserDict.Remove(color);
                }
            }


            //Add Lasers to the dictionary from the "toAdd stack"
            while (_lasersToAddStack.Count > 0)
            {
                Laser toAdd = _lasersToAddStack.Pop();
                STLColor color = toAdd.color;

                if (!_laserDict.ContainsKey(color)) // || !laserDict[kv.Key].Contains(kv.Value))
                {
                    _laserDict.Add(color, new List<Laser>() {toAdd});
                }
                else if (!_laserDict[color].Contains(toAdd))
                {
                    _laserDict[color].Add(toAdd);
                }
                else
                {
                    //Spotting an error where the same laser is being initialized twice is almost impossible sometimes
                    Debug.LogError("The laser you are trying to add is already in the laser dict");
                }
            }


            foreach (KeyValuePair<STLColor, List<Laser>> kv in _laserDict)
            foreach (Laser b in kv.Value)
                b.Refresh();
        }

        public void ShootLaser(STLColor color, Transform originPoint, Vector3 destination)
        {
            Laser laser = GameManager.Instance.LaserFactory.CreateLaser(color, originPoint, destination);
            AddLaser(laser);
        }

        private void AddLaser(Laser toAdd)
        {
            _lasersToAddStack.Push(toAdd);
        }

        public void RemoveLaser(Laser toRemove)
        {
            _lasersToRemoveStack.Push(toRemove);
        }
    }
}