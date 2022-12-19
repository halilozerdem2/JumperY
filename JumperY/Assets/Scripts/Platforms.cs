using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public new Collider2D  collider2D;
    public GameObject player; 

    private void Awake()
    {
        collider2D= GetComponent<Collider2D>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(player.transform.position.y>this.transform.position.y+1f)
            collider2D.isTrigger = false;
        else
            collider2D.isTrigger = true;
    }
}
