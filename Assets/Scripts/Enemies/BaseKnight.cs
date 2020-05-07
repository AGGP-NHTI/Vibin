using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKnight : BaseStandardEnemy
{
    public enemyhitbox sight;
    public enemyhitbox sword;
    public AudioSource source;
    public AudioClip clip;
    bool frame1 = true;

    public float attacktime = 0.2f;
    public float timeleft;
    public float wait = 1f;
    float WT;

    void Start()
    {       
        timeleft = attacktime;
        sword.transform.gameObject.SetActive(false);
        WT = wait;
    }
    void FixedUpdate()
    {
        if (sight.hit)
        {
            currentaction = Attack;
        }
        if (currentaction == Die || currentaction == Recoil)
        {
            sword.transform.gameObject.SetActive(false);
        }
    }
    public void Attack()
    {
        WT -= Time.fixedDeltaTime;
        if (WT <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            timeleft -= Time.fixedDeltaTime;
            if (timeleft >= 0)
            {
                if (frame1)
                {
                    source.PlayOneShot(clip, PlayerPrefs.GetFloat("Effects", 0.5f));
                    frame1 = false;
                }
                sword.transform.gameObject.SetActive(true);
                anim.SetBool("AttackingAnim", true);
            }
            else
            {
                currentaction = Default;
                timeleft = attacktime;
                sword.transform.gameObject.SetActive(false);
                anim.SetBool("AttackingAnim", false);
                WT = wait;
                rb.constraints = RigidbodyConstraints2D.None;
                
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                frame1 = true;
            }
        }
    }
}
