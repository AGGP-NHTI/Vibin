﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : PWPawn
{
    public int damage = 5;
    public float speed = 2f;
    public bool attacked = false;
    public float knockback = 5f;
    public Rigidbody2D rb;
    protected Vector3 localScale;
    public bool direction = false;
    public float pknockback = 5f;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!attacked)
        {
            PlayerPawn playerPawn = collision.collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
            if (playerPawn != null)
            {
                playerPawn.TakeDamage(null, damage, null, null);
                //playerPawn.rb.Addforce(gameObject.transform.forward * pknockback);
            }
        }
    }
    public void GotHit()
    {
        attacked = true;
    }
}
