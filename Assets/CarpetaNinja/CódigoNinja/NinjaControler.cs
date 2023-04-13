using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NinjaControler : MonoBehaviour
{
    public float runSpeeed = 10;
    public float jumpSpeed = 8;

   // para el doble salto
    public float doubleJumpSpeed = 15;
    private bool canDoubleJump;
    
    
    Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;

    Animator animacion;
    public int Idle;
    public int Correr;
    public int Saltar;
    public int Atacar;
    public int Lanzar;
    public int Deslizar;
    public int Morir;


    private bool bandera = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }
    
    //para el doble salto
    private void Update()
    {
        if (Input.GetKey("space") )
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                ChangeAnimation(Saltar);
            }
            else
            {
                //fruta
                if (Input.GetKeyDown("m") )
                {
                   if (canDoubleJump)
                    {
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
           
        }

    }

    //cierre salto doble

    void FixedUpdate()
    {
        if (bandera == false)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb2D.velocity = new Vector2(runSpeeed, rb2D.velocity.y);
                spriteRenderer.flipX = false;
                ChangeAnimation(Correr);
            }

            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb2D.velocity = new Vector2(-runSpeeed, rb2D.velocity.y);
                spriteRenderer.flipX = true;
                ChangeAnimation(Correr);
            }

            else
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                ChangeAnimation(Idle);
            }
            
           // if (Input.GetKey("space")&& CheckGround.isGrounded)
           // {
             //   rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
               // ChangeAnimation(Saltar);
            //}


        }

        if (Input.GetKey("z"))
        {
            ChangeAnimation(Atacar);
        }

        if (Input.GetKey("x"))
        {
            ChangeAnimation(Lanzar);
        }

        if (Input.GetKey("v"))
        {
            ChangeAnimation(Deslizar);
        }

        if (Input.GetKey("b"))
        {
            ChangeAnimation(Morir);
            bandera = true;
            Destroy(gameObject, 0.8f);
        }
    }
    private void ChangeAnimation(int animat)
    {
        animacion.SetInteger("Estado",animat);
    }
}
