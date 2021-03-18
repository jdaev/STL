using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 2f;
    
    public int HitCount { get; private set; } = 0;
    public void Initialize()
    {
        
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
        if(transform.position.z<387)
            transform.Translate(transform.forward * (speed * Time.deltaTime));
    }

    public void Stop()
    {
        
    }
}
