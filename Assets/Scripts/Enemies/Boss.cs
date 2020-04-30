﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : BaseEnemy
{
    public Animator anim;
    delegate void currentAction();
    currentAction currentaction;
    currentAction nextaction;

    public bool phase2 = false;
    public GameObject parent;
    public EnemyProjectile fire;
    public GameObject fireball;
    public float deathtime = 5f;
    public float downtime;
    float currenttime;
    public GameObject Mouth;
    public GameObject blitzpoint;
    
    public BossLocation location;
    public float range;
    public float volley = 1f;
    float v;
    public int volleyAmount = 3;
    int VA;
    public bool FB = false;
    bool ff = true;
   
    public AudioSource source;

    public List<GameObject> IdleList;
    public int IdleListIndex = 0;

    public List<GameObject> HfireList;
    public int HFireListIndex = 0;
    public List<jets> Jets;
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
        nextaction = fball;
        v = volley;
        VA = volleyAmount;
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
        if (Health <= (StartingHealth / 3) && !phase2)
        {
            SecondPhase();
        }
        if (Health <= 0)
        {
            currentaction = Die;
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
            nextaction = fball;
            
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
    public void fball()
    {
        if (!spinning)
        {
            location.currentTarget = blitzpoint;
        }
        if (Vector3.Distance(blitzpoint.transform.position, gameObject.transform.position) <= 0.3f)
        {
            spinning = true;
        }
        if (spinning)
        {
            v -= Time.fixedDeltaTime;
            if (v <= 0 && VA > 0)
            {
                GameObject clone;
                clone = Instantiate(fireball, Mouth.transform.position, Mouth.transform.rotation);
                v = volley;
                VA--;
            }
            if (VA <= 0)
            {
                spinning = false;
                v = volley;
                VA = volleyAmount;
                nextaction = HFire;
                currentaction = Idle;
            }
        }
    }
    public void SecondPhase()
    {
        phase2 = true;
        foreach (jets i in Jets)
        {
            i.On = true;
        }
        volleyAmount = volleyAmount * 2;
    }
    public void Die()
    {
        deathtime -= Time.fixedDeltaTime;
        if (deathtime <= 0)
        {
            Destroy(parent);
        }
    }
}
