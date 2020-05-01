﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jets : MonoBehaviour
{
    public EnemyProjectile projectile;
    public GameObject spawnpoint;
    public float frequency = 0.1f;
    float t;
    public bool On = true;

    
    void Start()
    {
        t = frequency;
    }

    
    void Update()
    {
        if (On)
        {
            t -= Time.fixedDeltaTime;
            if (t <= 0)
            {
                EnemyProjectile clone;
                clone = Instantiate(projectile, spawnpoint.transform.position, spawnpoint.transform.rotation);
                t = frequency;
            }
        }
    }
}
