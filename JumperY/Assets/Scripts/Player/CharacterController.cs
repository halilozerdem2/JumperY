using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CharacterController : MonoBehaviour
{
    public CollisionDetecter detecter;
    public SpeedController speedController;

    private Rigidbody2D playerRb;

    private Vector2 playerPos;

    [SerializeField] float movingSpeed= 1500f;
    [SerializeField] float bounceSpeed = 200f;

    private float jumpForce;


    private void Awake()
    {
        detecter= GetComponent<CollisionDetecter>();
        speedController= GetComponent<SpeedController>();
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetJumpPower();
    
    }

    private void FixedUpdate()
    {
        Move();
        
        if (detecter.isGrounded && Input.GetKey(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        float jumpAmount = jumpForce * Time.deltaTime;
        playerRb.velocity=new Vector2 (playerRb.velocity.x, jumpForce);
    }

    private void Move()
    {
       float moveAmount = Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime;
        if (!detecter.isGrounded)
            moveAmount *= 2;
        //Debug.Log(moveAmount);
        
        if(Mathf.Abs(playerRb.velocity.x)<=15)
        {
            playerRb.AddForce(new Vector2(moveAmount, playerRb.velocity.y));

            if (detecter.isHitRightWall)
                playerRb.AddForce(new Vector2(-bounceSpeed, playerRb.velocity.y));
         
            else if (detecter.isHitLeftWall)
                playerRb.AddForce(new Vector2(bounceSpeed, playerRb.velocity.y));

        }
        
    }
    private float SetJumpPower()
    {
        Debug.Log(playerRb.velocity.x);
        
        if(Mathf.Abs(playerRb.velocity.x) == 0) 
            jumpForce= 6f;

        else if((Mathf.Abs(playerRb.velocity.x) > 0 && (Mathf.Abs(playerRb.velocity.x) < 5)))
            jumpForce = 7f;
        else if((Mathf.Abs(playerRb.velocity.x) > 5 && (Mathf.Abs(playerRb.velocity.x) < 10)))
            jumpForce = 8f;
        else
            jumpForce = 10f;

        return jumpForce;
    }
    public Vector2 GetPlayerPos() 
    { 
        playerPos=transform.GetChild(0).position;
        return playerPos; 
    }

}
