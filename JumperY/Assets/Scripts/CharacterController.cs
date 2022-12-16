using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField] float movingSpeed= 600f;
    [SerializeField] float bounceSpeed = 200f;
    [SerializeField] float jumpForce= 5f;


    private bool isGrounded;
    private bool isHitRigthWall;
    private bool isHitLeftWall;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
        else if (collision.gameObject.CompareTag("RightWall"))
            isHitRigthWall = true;
        else if (collision.gameObject.CompareTag("LeftWall"))
            isHitLeftWall = true;

    } 

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
        else if (collision.gameObject.CompareTag("RightWall"))
            isHitRigthWall = false;
        else if (collision.gameObject.CompareTag("LeftWall"))
            isHitLeftWall = false;

    }

    private void FixedUpdate()
    {
        Move();
        
        if (isGrounded && Input.GetKey(KeyCode.Space))
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
        Debug.Log(moveAmount);
        
        if(Mathf.Abs(playerRb.velocity.x)<=15)
        {
            playerRb.AddForce(new Vector2(moveAmount, playerRb.velocity.y));

            if (isHitRigthWall)
                playerRb.AddForce(new Vector2(-bounceSpeed, playerRb.velocity.y));
            else if(isHitLeftWall)
                playerRb.AddForce(new Vector2(bounceSpeed, playerRb.velocity.y));

        }
        
    }

}
