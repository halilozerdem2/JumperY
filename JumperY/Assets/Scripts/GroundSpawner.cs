using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public List<GameObject> platformPrefabs;
    public CharacterController player;
    public int spawnCount=0;
    Vector3 spawnPoint;

    private void Awake()
    { 
        player=FindObjectOfType<CharacterController>();
        spawnPoint = new Vector3(0,-1,0);
    }
    private void Start()
    {
        SpawnPlatform();

    }
    private void Update()
    {
        if(Mathf.Abs(player.GetPlayerPos().y-spawnPoint.y)< 5f) 
        {
            SpawnPlatform();
        }

    }
    public void SpawnPlatform()
    {
        GameObject temp = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Count - 1)], spawnPoint, Quaternion.identity);
        spawnPoint = temp.transform.GetChild(0).transform.position;
        spawnCount++;
        Destroy(temp, 30f);
    }

}
