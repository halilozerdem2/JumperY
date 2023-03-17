using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public CharacterController player;
    public GroundSpawner groundSpawner;
    
    public Vector2 cameraPos;
    private Vector3 cameraTarget;
    public float cameraMovingSpeed = 2f;
    public bool isWithinViewport = false;
    public bool isGameOver;

    private Camera mainCamera;

    private void Awake()
    {
        player = FindObjectOfType<CharacterController>();
        groundSpawner=FindObjectOfType<GroundSpawner>();
        mainCamera = Camera.main;
    }
    private void Start()
    {
        cameraTarget = new Vector3(0, 0, -1);
    }
    private void Update()
    {
        CheckBoundries();
        cameraMovingSpeed = (groundSpawner.spawnCount+3)/1.25f * Time.deltaTime;
    }
    private void LateUpdate()
    {
        MoveCamera();
    }

    private void CheckBoundries()
    {
        isWithinViewport = mainCamera.WorldToViewportPoint(player.gameObject.
                           transform.position).y > 0;
    }

    private void MoveCamera()
    {
        cameraTarget = this.transform.position + new Vector3(0, 0.5f, 0);

        if (player.isMovingUp)
        {
            Vector3 characterTarget = new Vector3(0, player.GetPlayerPos().y + 2f, -1f);
            this.transform.position = Vector3.Lerp(transform.position,
                                      characterTarget, cameraMovingSpeed*2f);
        }
        else
        {
            this.transform.position = Vector3.Lerp(transform.position, 
                                      cameraTarget, cameraMovingSpeed);
        }
        if (!isWithinViewport)
        {
            //Game Over
            SceneManager.LoadScene("MainMenu");
        }
    }

}
