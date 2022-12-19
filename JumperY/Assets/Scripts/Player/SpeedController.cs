using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    CollisionDetecter collisionDetecter;

    private void Awake()
    {
        collisionDetecter= GetComponent<CollisionDetecter>();
    }
    private void Update()
    {
        
    }
}
