using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jets : MonoBehaviour
{
    public EnemyProjectile projectile;
    public GameObject spawnpoint;
    public float frequency = 0.1f;
    float t;
    public bool On = true;
    public float rdm = 0.1f;
    
    void Start()
    {
        t = frequency;
    }

    
    void FixedUpdate()
    {
        if (On)
        {
            float space = Random.Range(-rdm, rdm);
            t -= Time.fixedDeltaTime;
            if (t <= 0)
            {
                EnemyProjectile clone;
                clone = Instantiate(projectile, new Vector3 (spawnpoint.transform.position.x + space, spawnpoint.transform.position.y, spawnpoint.transform.position.z), spawnpoint.transform.rotation);
                t = frequency;
            }
        }
    }
}
