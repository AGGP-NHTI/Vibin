using System.Collections;
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
    public Animator anim;

    bool FF = true;
    
    
    public void HitCheck()
    {
        if (attacked)
        {
            currentaction = Recoil;
        }
    }

    public virtual void Default()
    {

    }

    public override void Damage(bool KB)
    {
        base.Damage(KB);
        currentaction = Recoil;
    }
    public virtual void Recoil()
    {
       
        if (FF)
        {
            groundcheck.gameObject.SetActive(false);
            anim.SetBool("GettingHitAnim", true);
            if (KBdir)
            {
                rb.AddForce(gameObject.transform.up * knockback);
                rb.AddForce(gameObject.transform.right * knockback);               
            }
            else
            {
                rb.AddForce(gameObject.transform.up * knockback);
                rb.AddForce(gameObject.transform.right * -knockback);
            }
            attacked = true;
            anim.SetBool("GettingHitAnim", true);
            Debug.Log("hit!!!!!!");
            FF = false;
        }
        if (rb.velocity.y <= 0)
        {
            groundcheck.gameObject.SetActive(true);
        }
        if (groundcheck.bash)
        {
            FF = true;
            attacked = false;
            if (Health <= 0)
            {
                currentaction = Die;
            }
            else
            {
                currentaction = Default;
                anim.SetBool("GettingHitAnim", false);
            }
        }
    }
    public virtual void Die()
    {
        anim.SetBool("DyingAnim", true);
        deathtime -= Time.fixedDeltaTime;
        if (deathtime <= 0)
        {           
                Destroy(Parent);            
        }
    }
}
