using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCon : MonoBehaviour
{
    Rigidbody2D rigbd;
    public float run = 2;
    public static bool zom;


    void Start()
    {
        rigbd = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        rigbd.velocity = new Vector2(-run, rigbd.velocity.y);
        

    }
    
    

}
