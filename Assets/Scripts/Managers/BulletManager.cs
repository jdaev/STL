using System.Collections.Generic;
using Base;
using UnityEngine;

namespace Managers
{
    public class BulletManager
{
    private static BulletManager _instance;

    public static BulletManager Instance => _instance ??= new BulletManager();
    private Dictionary<STLColor, List<Bullet>> _bulletDict;
    private Stack<Bullet> _bulletsToRemoveStack;
    private Stack<Bullet> _bulletsToAddStack;

    private BulletManager()
    {
        _bulletDict = new Dictionary<STLColor, List<Bullet>>();
        _bulletsToRemoveStack = new Stack<Bullet>();
        _bulletsToAddStack = new Stack<Bullet>();
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
        while (_bulletsToRemoveStack.Count > 0)
        {
            Bullet toRemove = _bulletsToRemoveStack.Pop();
            STLColor color = toRemove.color;
            if (!_bulletDict.ContainsKey(color) || !_bulletDict[color].Contains(toRemove))
            {
                Debug.LogError("Stack tried to remove element of type: " + color.ToString() +
                               " but was not found in dictionary?");
            }
            else
            {
                _bulletDict[color].Remove(toRemove);
                ObjectPool.Instance.AddToPool(toRemove.color.ToString(), toRemove);
                if (_bulletDict[color].Count == 0)
                    _bulletDict.Remove(color);
            }
        }


        //Add Bullets to the dictionary from the "toAdd stack"
        while (_bulletsToAddStack.Count > 0)
        {
            Bullet toAdd = _bulletsToAddStack.Pop();
            STLColor color = toAdd.color;

            if (!_bulletDict.ContainsKey(color)) // || !bulletDict[kv.Key].Contains(kv.Value))
            {
                _bulletDict.Add(color, new List<Bullet>() {toAdd});
            }
            else if (!_bulletDict[color].Contains(toAdd))
            {
                _bulletDict[color].Add(toAdd);
            }
            else
            {
                //Spotting an error where the same bullet is being initialized twice is almost impossible sometimes
                Debug.LogError("The bullet you are trying to add is already in the bullet dict");
            }
        }


        foreach (KeyValuePair<STLColor, List<Bullet>> kv in _bulletDict)
        foreach (Bullet b in kv.Value)
            b.Refresh();
    }

    public void ShootBullet(STLColor type, Vector3 originPoint)
    {
        Bullet bullet = BulletFactory.Instance.CreateBullet(type, originPoint);
        AddBullet(bullet);
    }
    
    public void AddBullet(Bullet toAdd)
    {
        _bulletsToAddStack.Push(toAdd);
    }

    public void RemoveBullet(Bullet toRemove)
    {
        _bulletsToRemoveStack.Push(toRemove);
    }
}
}