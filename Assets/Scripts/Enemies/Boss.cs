using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : BaseEnemy
{
    delegate void currentAction();
    currentAction currentaction;

    public EnemyProjectile fire;
    public float downtime;
    float currenttime;
    public GameObject Mouth;
    public GameObject parent;

    bool FB = false;
    public GameObject HFirePoint1;
    public GameObject HFirePoint2;
    public GameObject SpinPoint;
    int index = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        currenttime = downtime;
        currentaction = HFire; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FB)
        {
            EnemyProjectile clone;
            clone = Instantiate(fire, Mouth.transform.position, Mouth.transform.rotation);
            clone.transform.SetParent(parent.transform);
        }
        currentaction();
    }
    public void Idle()
    {
        currenttime -= Time.fixedDeltaTime;
        if (currenttime <= 0)
        {
            currenttime = downtime;
            if (index == 1)
            {
                currentaction = HFire;
            }
        }
    }

    public void HFire()
    {
        bool finished = false;

        if (finished)
        {
            finished = false;
            currentaction = Idle;
            index++;
        }
    }
    public void Spin()
    {

    }

    public override void GotHit()
    {

    }
}
