using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using Managers;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int HitCount { get; private set; } = 0;

    public void Initialize()
    {
        transform.position.Set(0,GameManager.Instance.PlayerHeight,0);
    }

    public void Refresh()
    {
        Move();
    }
    public void Kill()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Kill();
            HitCount++;
        }
    }

    private void Move()
    {   
        
        if(transform.position.z<GameManager.Instance.Level.levelLength)
            transform.Translate(transform.forward * (GameManager.Instance.Level.playerSpeed * Time.deltaTime));
    }

    public void Stop()
    {
        
    }
}
