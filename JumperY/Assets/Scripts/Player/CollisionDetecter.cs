using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    //public Timer wallHitTimer;
    //public Timer comboTimer;
    public bool isGrounded;
    public bool isHitRightWall;
    public bool isHitLeftWall;
    public bool jumping;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
        
        else if (collision.gameObject.CompareTag("RightWall"))
            isHitRightWall = true;
        else if (collision.gameObject.CompareTag("LeftWall"))
            isHitLeftWall = true;

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;

        else if (collision.gameObject.CompareTag("RightWall"))
            isHitRightWall = false;
        else if (collision.gameObject.CompareTag("LeftWall"))
            isHitLeftWall = false;

    }
}
