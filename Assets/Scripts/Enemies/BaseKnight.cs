using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKnight : BaseStandardEnemy
{
    public enemyhitbox sight;
    public enemyhitbox sword;
    protected Animator anim;

    public float attacktime = 1f;
    public float timeleft;
    

    void Start()
    {       
        timeleft = attacktime;
        sword.transform.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        if (sight.hit)
        {
            currentaction = Attack;
        }
    }
    public void Attack()
    {
        timeleft -= Time.fixedDeltaTime;
        if (timeleft >= 0)
        {
            sword.transform.gameObject.SetActive(true);
            anim.SetBool("AttackingAnim", true);
        }
        else
        {
            currentaction = Default;
            timeleft = attacktime;
            sword.transform.gameObject.SetActive(false);
            anim.SetBool("AttackingAnim", false);
        }
    }
}
