using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : PWPawn
{
    public bool testdamage = false;
    public int damage = 1;
    public float speed = 2f;
    public bool attacked = false;
    public float knockback = 5f;
    protected bool candamage = true;
    
    protected Vector3 localScale;
    public Vector3 dir;
    public bool direction = false;
    
    public Slider slider;
    
    public bool KBdir = false;

   
    void Start()
    {
        localScale = transform.localScale;
        dir = gameObject.transform.position;
    }

    void Update()
    {
        slider.value = Health;
        if (Input.GetKeyDown(KeyCode.H) && testdamage)
        {
            Damage(true);
        }
        dir = gameObject.transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!attacked)
        {
            PlayerPawn playerPawn = collision.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
            if (playerPawn != null)
            {
                if (candamage)
                {
                    playerPawn.TakeDamage(null, damage, null, null);
                }
                
            }
        }
    }
    public virtual void Damage(bool KB)
    {
        if (!attacked)
        {
            KBdir = KB;
            Health--;
            attacked = true;
        }
    }


}
