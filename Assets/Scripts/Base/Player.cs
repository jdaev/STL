using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 2f;
    private int hitCount = 0;
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
            hitCount++;
        }
    }

    private void Move()
    {   if(transform.position.z<85)
        transform.Translate(transform.forward * (speed * Time.deltaTime));
    }

    public void Stop()
    {
        
    }
}
