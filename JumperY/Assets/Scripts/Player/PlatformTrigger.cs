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
        platformCollider.enabled = true;
        platformCollider.isTrigger = true;
    }
    private void Update()
    {
        if (playerController.GetPlayerPos().y+0.1f > this.transform.position.y)
            canCollide = true;
        else 
            canCollide= false;
        
    }
    private void FixedUpdate()
    {
        if(canCollide) 
            platformCollider.isTrigger= false;
        else
            platformCollider.isTrigger= true;
    }
   
}
