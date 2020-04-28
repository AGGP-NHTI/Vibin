using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKnight : BaseStandardEnemy
{
    public enemyhitbox sight;
    public enemyhitbox sword;
    

    public float attacktime = 1f;
    protected float timeleft;
    

    void Start()
    {       
        timeleft = attacktime;
        sword.transform.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        if (sight.bash)
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
        }
        else
        {
            currentaction = Default;
            timeleft = attacktime;
            sword.transform.gameObject.SetActive(false);
        }
    }
}
