﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStandardEnemy : BaseEnemy
{
    public delegate void currentAction();
    public currentAction currentaction;
    public GameObject Parent;
    public enemyhitbox groundcheck;
    public float deathtime = 2f;
    public Rigidbody2D rb;

    bool FF = true;
    
    void FixedUpdate()
    {
        if (attacked)
        {
            currentaction = Recoil;
        }
    }

    public virtual void Default()
    {

    }

    public virtual void Recoil()
    {
        if (FF)
        {
            if (KBdir)
            {
                rb.AddForce(gameObject.transform.up * knockback);
                rb.AddForce(gameObject.transform.right * knockback);               
            }
            else
            {
                rb.AddForce(gameObject.transform.up * -knockback);
                rb.AddForce(gameObject.transform.right * -knockback);
            }
            attacked = true;
        }
        if (groundcheck.bash)
        {
            attacked = false;
            if (Health <= 0)
            {
                currentaction = Die;
            }
            else
            {
                currentaction = Default;
            }
        }
    }
    public virtual void Die()
    {
        deathtime -= Time.fixedDeltaTime;
        if (deathtime <= 0)
        {
            Destroy(Parent);
        }
    }
}