using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuard : BaseStandardEnemy
{
    public Vision vision;
    public EnemyProjectile projectile;
    public GameObject spawnpoint;
    
    public float rechargeTime = 4f;
    float currenttime;
    
    void Start()
    {
        slider.maxValue = StartingHealth;
        currenttime = rechargeTime;
        currentaction = Default;
    }

   
    void FixedUpdate()
    {
        currentaction();
    }
    public override void Default()
    {
        currenttime -= Time.fixedDeltaTime;
        if (currenttime <= 0)
        {
            if (vision.sighted)
            {
                EnemyProjectile clone;
                clone = Instantiate(projectile, spawnpoint.transform.position, spawnpoint.transform.rotation);

                currenttime = rechargeTime;
            }
        }
    }
}
