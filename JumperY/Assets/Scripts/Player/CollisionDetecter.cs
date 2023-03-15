using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    public CharacterController playerController;
    public CapsuleCollider2D collider;

    public GameObject RightWall;
    public GameObject LeftWall;

    public bool isGrounded;
    public bool isHitRightWall;
    public bool isHitLeftWall;
    public bool isJumping;
    public bool canJump;

    private void Awake()
    {
        playerController = FindObjectOfType<CharacterController>();
        collider = GetComponent<CapsuleCollider2D>();
        RightWall = GameObject.FindWithTag("RightWall");
        LeftWall = GameObject.FindWithTag("LeftWall");
    }

    private void Update()
    {/*
        if (playerController.GetComponent<Rigidbody2D>().velocity.y > 0.3f && !isGrounded)
        {
            if (Mathf.Abs(this.gameObject.transform.position.x - LeftWall.transform.position.x) < 0.4f ||
                Mathf.Abs(this.gameObject.transform.position.x - RightWall.transform.position.x) < 0.4f)
            {
                collider.isTrigger = false;
            }
            else
            collider.isTrigger = true;
        }
        else
            collider.isTrigger = false;
        */
    }
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.coolDown = 0;
            isGrounded = true;
            isJumping = false;
        }

        else if (collision.gameObject.CompareTag("RightWall"))
            isHitRightWall = true;
        else if (collision.gameObject.CompareTag("LeftWall"))
            isHitLeftWall = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
        }
        else if (collision.gameObject.CompareTag("RightWall"))
            isHitRightWall = false;
        else if (collision.gameObject.CompareTag("LeftWall"))
            isHitLeftWall = true;
    }

}
