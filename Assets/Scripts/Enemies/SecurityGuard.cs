using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuard : BaseStandardEnemy
{
    public Vision vision;
    public taser projectile;
    public GameObject spawnpoint;
    
    public float rechargeTime = 4f;
    float currenttime;
    public float shoottime = 0.5f;
    float stime;
    float taseTime;
    bool firstframe = true;
    
    void Start()
    {
        slider.maxValue = StartingHealth;
        currenttime = 0;
        currentaction = Default;
        stime = shoottime;
        taseTime = projectile.tazetime;
    }

   
    void FixedUpdate()
    {
        currentaction();
        HitCheck();
    }
    public override void Default()
    {
        currenttime -= Time.fixedDeltaTime;
        if (currenttime <= 0)
        {
            if (vision.sighted)
            {
                currentaction = shoot;
                
            }
        }
    }
    public void shoot()
    {
        stime -= Time.fixedDeltaTime;
        anim.SetBool("AttackingAnim", true);
        if (stime <= 0)
        {
            if (firstframe)
            {
                
                EnemyProjectile clone;
                clone = Instantiate(projectile, spawnpoint.transform.position, spawnpoint.transform.rotation);
                firstframe = false;
            }
            else
            {
                taseTime -= Time.fixedDeltaTime;
                if (taseTime <= 0)
                {
                    stime = shoottime;
                    currenttime = rechargeTime;
                    currentaction = Default;
                    firstframe = true;
                    anim.SetBool("AttackingAnim", false);
                }
            }
        }
    }
}
