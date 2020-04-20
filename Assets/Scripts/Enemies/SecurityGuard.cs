using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuard : BaseEnemy
{
    public Vision vision;
    public EnemyProjectile projectile;
    public GameObject spawnpoint;
    public GameObject parent;
    public float rechargeTime = 4f;
    float currenttime;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = rechargeTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currenttime -= Time.fixedDeltaTime;
        if (currenttime <= 0)
        {
            if (vision.sighted)
            {
                EnemyProjectile clone;
                clone = Instantiate(projectile, spawnpoint.transform.position, spawnpoint.transform.rotation);
                clone.transform.SetParent(parent.transform);
                currenttime = rechargeTime;
            }
        }
    }
}
