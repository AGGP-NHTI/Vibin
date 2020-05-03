using System.Collections;
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
    public GameObject fireball2;
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
    public float firefrequency = 0.1f;
    float fre;
    bool ff = true;
   
    public AudioSource source;
    public AudioClip fbs;
    public AudioClip roar;

    public List<GameObject> IdleList;
    public int IdleListIndex = 0;

    public List<GameObject> HfireList;
    public int HFireListIndex = 0;

    public List<GameObject> HfireList2;
    public int HFireListIndex2 = 0;

    public List<jets> Jets;
    
    GameObject currentTarget;

    public GameObject SpinPoint;
    public GameObject SpinPoint2;
    public GameObject back;
   
    public int index = 0;
    bool spinning = false;
    bool passed = false;

    bool spincycle = false;
    
    void Start()
    {
        fre = firefrequency;
        slider.maxValue = StartingHealth;
        currenttime = downtime;
        currentaction = Begin;
        location.movespeed = speed;
        location.WithinRange = range;
        nextaction = HFire;
        v = volley;
        VA = volleyAmount;
        localScale = transform.localScale;
        slider.value = 0;
        source.volume = PlayerPrefs.GetFloat("Effects");
    }
    void Update()
    {
        if (currentaction != Begin)
        {
            slider.value = Health;
        }
    }
    void FixedUpdate()
    {
        if (!spinning)
        {
            gameObject.transform.position = location.transform.position;
        }
        if (FB)
        {
            anim.SetBool("FBAnim", true);
            fre -= Time.fixedDeltaTime;
            if (fre <= 0)
            {
                EnemyProjectile clone;
                clone = Instantiate(fire, Mouth.transform.position, Mouth.transform.rotation);
                fre = firefrequency;
            }
        }
        else
        {
            anim.SetBool("FBAnim", false);
        }
        if (Health <= (StartingHealth / 3) && !phase2)
        {
            SecondPhase();
        }
        if (Health <= 0)
        {
            currentaction = Die;
        }
        transform.localScale = localScale;
        currentaction();
    }
    public void Begin()
    {
        slider.value += 5f * Time.fixedDeltaTime;

        location.currentTarget = IdleList[IdleListIndex];

        if (location.IsCloseToTarget())
        {
            currentaction = Idle;
        }
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
            if (phase2)
            {
                currentaction = HFire2;
                finished = false;
                FB = false;
            }
            else
            {
                finished = false;
                currentaction = Idle;
                nextaction = Spin;
            }
        }
    }
    public void HFire2()
    {
        bool finished = false;

        location.currentTarget = HfireList2[HFireListIndex2];
        
        if (location.IsCloseToTarget())
        {
            if (HFireListIndex2 <= HfireList2.Capacity - 2)
            {
                HFireListIndex2++;
                
                if (HFireListIndex2 == 1 || HFireListIndex2 == 3)
                {
                    FB = true;
                    source.UnPause();
                    localScale.y *= -1;
                }
                else
                {
                    FB = false;
                    source.Pause();
                   
                }
                if (HFireListIndex2 == 1)
                {
                    gameObject.transform.rotation = back.transform.rotation;
                }
            }
            else
            {
                finished = true;
                HFireListIndex2 = 0;
            }
        }
        if (finished)
        {           
            {
                finished = false;
                currentaction = Idle;
                nextaction = Spin;
                gameObject.transform.rotation = Quaternion.identity;
                
            }
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
            nextaction = fballStart;
            
        }
    
        if (gameObject.transform.position.x <= SpinPoint.transform.position.x)
        {
            passed = true;
        }
        if (passed && Vector3.Distance(back.transform.position, gameObject.transform.position) <= 1)
        {
            if (!spincycle)
            {
                gameObject.transform.SetParent(null);
                gameObject.transform.rotation = Quaternion.identity;
                spinning = false;
                currentaction = Idle;
                passed = false;
                FB = false;
                source.Stop();
                ff = true;
                if (phase2)
                {
                    spincycle = true;
                }
            }
            else
            {
                currentaction = Spin3;
                ff = true;
                passed = false;
            }
        }
        
    }
    public void Spin3()
    {
        if (ff)
        {
            gameObject.transform.SetParent(SpinPoint2.transform);
            localScale.y *= -1;
            ff = false;
        }
        if (gameObject.transform.position.x <= SpinPoint.transform.position.x)
        {
            passed = true;
        }
        if (passed && Vector3.Distance(back.transform.position, gameObject.transform.position) <= 1)
        {
            currentaction = Spin2;
            spincycle = false;
            passed = false;
            gameObject.transform.SetParent(SpinPoint.transform);
            localScale.y *= -1;
        }
    }
    public void fballStart()
    {
        VA = volleyAmount;
        currentaction = fball;
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
                source.PlayOneShot(fbs, PlayerPrefs.GetFloat("Effects"));
                if (VA % 2 == 0)
                {
                    GameObject clone;
                    clone = Instantiate(fireball, Mouth.transform.position, Mouth.transform.rotation);
                    v = volley;
                    VA--;
                }
                else
                {
                    GameObject clone;
                    clone = Instantiate(fireball2, Mouth.transform.position, Mouth.transform.rotation);
                    v = volley;
                    VA--;
                }
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
        spincycle = true;
        source.PlayOneShot(roar, PlayerPrefs.GetFloat("Effects", 0.5f));
    }
    public override void Damage(bool KB)
    {
        base.Damage(KB);
        attacked = false;
        if (Health <= 0)
        {
            currentaction = Die;
            anim.SetBool("DyingAnim", true);
            FB = false;
        }
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
