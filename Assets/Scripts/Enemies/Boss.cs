using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : BaseEnemy
{
    delegate void currentAction();
    currentAction currentaction;
    currentAction nextaction;
    

    public EnemyProjectile fire;
    public float downtime;
    float currenttime;
    public GameObject Mouth;
    
    public BossLocation location;
    public float range;
    public bool FB = false;
    bool ff = true;
   
    public AudioSource source;

    public List<GameObject> IdleList;
    public int IdleListIndex = 0;

    public List<GameObject> HfireList;
    public int HFireListIndex = 0;

    GameObject currentTarget;

    public GameObject SpinPoint;
    public GameObject back;
   
    public int index = 0;
    bool spinning = false;
    bool passed = false;
    
    void Start()
    {
        slider.maxValue = StartingHealth;
        currenttime = downtime;
        currentaction = Idle;
        location.movespeed = speed;
        location.WithinRange = range;
        nextaction = Spin;
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
                
                currentaction = nextaction;                    
                
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
                    source.UnPause();
                }
                else
                {
                    FB = false;
                    source.Pause();
                }
            }
            else
            {
                finished = true;
                HFireListIndex = 0;
            }
        }
        if (finished)
        {
            finished = false;
            currentaction = Idle;
            nextaction = Spin;
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
        if (ff)
        {
            FB = true;
            source.Play();
            ff = false;
            gameObject.transform.SetParent(SpinPoint.transform);
            spinning = true;
            nextaction = HFire;
            
        }
    
        if (gameObject.transform.position.x <= SpinPoint.transform.position.x)
        {
            passed = true;
        }
        if (passed && Vector3.Distance(back.transform.position, gameObject.transform.position) <= 1)
        {
            gameObject.transform.SetParent(null);
            gameObject.transform.rotation = Quaternion.identity;
            spinning = false;
            currentaction = Idle;
            passed = false;
            FB = false;
            source.Stop();
            ff = true;
        }
        
    }
    
}
