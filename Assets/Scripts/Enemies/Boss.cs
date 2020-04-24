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
    public GameObject back;
    int index = 0;
    bool spinning = false;
    
    
    void Start()
    {
        slider.maxValue = StartingHealth;
        currenttime = downtime;
        currentaction = Idle;
        location.movespeed = speed;
        location.WithinRange = range;
    }
    
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
        FB = false;
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
                if (index == 0)
                {
                    currentaction = HFire;
                    index++;
                }
                if (index == 1)
                {
                    currentaction = Spin;
                    index++;
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
            if (HFireListIndex <= HfireList.Capacity - 2)
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
        location.currentTarget = back;

        if (location.IsCloseToTarget())
        {
            currentaction = Spin2;
        }

    }
    public void Spin2()
    {
        spinning = true;

        gameObject.transform.SetParent(SpinPoint.transform);

        FB = true;
    }
    
}
