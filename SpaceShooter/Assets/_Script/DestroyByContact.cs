﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(explosion,transform.position,transform.rotation);
        if(other.tag=="Player")
        {
            Instantiate(playerExplosion,other.transform.position,
                        other.transform.rotation);
        }
    }
}