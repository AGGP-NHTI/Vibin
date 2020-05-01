﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : PWPawn
{
    public int damage = 5;
    public float speed = 2f;
    public bool attacked = false;
    public float knockback = 5f;
    
    protected Vector3 localScale;
    public bool direction = false;
    public float pknockback = 5f;
    public Slider slider;
    
    public bool KBdir = false;

   
    void Start()
    {
        localScale = transform.localScale;
        
    }

    void Update()
    {
        slider.value = Health;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!attacked)
        {
            PlayerPawn playerPawn = collision.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
            if (playerPawn != null)
            {
                playerPawn.TakeDamage(null, damage, null, null);
                
            }
        }
    }
    public virtual void Damage(bool KB)
    {
        KBdir = KB;
        Health -= 1;
        attacked = true;
    }


}
