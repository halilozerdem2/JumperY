using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CharacterController player;
    public Vector3 cameraPos;

    private void Awake()
    {
        player=FindObjectOfType<CharacterController>();
    }
    private void Update()
    {
        cameraPos = new Vector3(transform.position.x, player.GetPlayerPos().y+ 3f, player.GetPlayerPos().z - 1f) ;
        transform.position = cameraPos;
    }

}
