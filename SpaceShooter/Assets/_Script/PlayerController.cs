﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }
    public Boundary boundary;
    public float speed = 5.0f;
    public float tilt = 4.0f;
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")&&Time.time>nextFire)
        {
            Debug.Log("Make a file");
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(moveHorizontal,0.0f,moveVertical);
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb!=null)
        {
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
            rb.velocity = movement * speed;
            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        }
    }
}
