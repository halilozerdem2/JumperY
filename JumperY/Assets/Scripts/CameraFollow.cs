using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraPos;

    private void Awake()
    {
        player=FindObjectOfType<CharacterController>().gameObject;
    }
    private void Update()
    {
        cameraPos = new Vector3(transform.position.x, player.transform.position.y+ 3f, player.transform.position.z - 1f) ;
        transform.position = cameraPos;
    }

}
