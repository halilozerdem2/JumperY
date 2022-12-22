using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public Collider2D platformCollider;

    private bool canCollide;
    CharacterController playerController;


    private void Awake()
    {
        playerController=FindObjectOfType<CharacterController>();
        platformCollider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        platformCollider.enabled = false;
    }
    private void Update()
    {
        if (playerController.GetPlayerPos().y > this.transform.position.y)
            canCollide = true;
        else 
            canCollide= false;
        
    }
    private void FixedUpdate()
    {
        if(canCollide) 
            platformCollider.enabled = true;
        else
            platformCollider.enabled = false;
    }
   
}
