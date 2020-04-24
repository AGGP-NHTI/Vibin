using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStandardEnemy : BaseEnemy
{
    public delegate void currentAction();
    public currentAction currentaction;

    public enemyhitbox groundcheck;

    
    bool FF = true;
    
    void Start()
    {
        
    }

    
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
            currentaction = Default;
        }
    }
    public virtual void Die()
    {

    }
}
