using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    public CharacterController playerController;
    public bool isGrounded;
    public bool isHitRightWall;
    public bool isHitLeftWall;
    public bool isJumping;

    private void Awake()
    {
        playerController= FindObjectOfType<CharacterController>();
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
            isJumping= true;
        }
        else if (collision.gameObject.CompareTag("RightWall"))
            isHitRightWall = false;
        else if (collision.gameObject.CompareTag("LeftWall"))
            isHitLeftWall = true;
    }
    
}
