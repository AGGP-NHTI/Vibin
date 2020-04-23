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
    
    public BossLocation location;
    public float range;
    public bool FB = false;
    public List<GameObject> IdleList;
    public int IdleListIndex = 0;

    public List<GameObject> HfireList;
    public int HFireListIndex = 0;

    GameObject currentTarget;

    public GameObject SpinPoint;
    int index = 0;
    bool spinning = false;

    // Start is called before the first frame update
    void Start()
    {
        currenttime = downtime;
        currentaction = Idle;
        location.movespeed = speed;
        location.WithinRange = range;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!spinning)
        {
            gameObject.transform.position = location.transform.position;
        }
        if (FB)
        {
            EnemyProjectile clone;
            clone = Instantiate(fire, Mouth.transform.position, Mouth.transform.rotation);
            
        }
        currentaction();
    }
    public void Idle()
    {
        location.currentTarget = IdleList[IdleListIndex];
        currenttime -= Time.fixedDeltaTime;
        if (location.IsCloseToTarget())
        {
            if (IdleListIndex >= IdleList.Capacity - 1)
            {
                IdleListIndex = 0;
            }
            else
            {
                IdleListIndex++;
            }
            if (currenttime <= 0)
            {
                currenttime = downtime;
                if (index == 1)
                {
                    currentaction = HFire;
                }
            }
        }
    }
    public void HFire()
    {
        bool finished = false;

        location.currentTarget = HfireList[HFireListIndex];
        if (location.IsCloseToTarget())
        {
            if (HFireListIndex <= HfireList.Capacity - 1)
            {
                HFireListIndex++;
                if (HFireListIndex == 1 || HFireListIndex == 3)
                {
                    FB = true;
                }
                else
                {
                    FB = false;
                }
            }
            else
            {
                finished = true;
            }
        }
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
