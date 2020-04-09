﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : BaseEnemy
{
    public Rigidbody2D rb;
    public bool direction = false;
    Vector3 localScale;
    public enemyhitbox hitbox;

    void Start()
    {
        localScale = transform.localScale;
    }
    void FixedUpdate()
    {
        transform.localScale = localScale;
        if (direction)
        {
            rb.velocity = new Vector3(1, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(-1, 0, 10);
        }
        if (hitbox.hit == true)
        {
            if (direction)
            {
                direction = false;
                localScale.x *= -1;
                hitbox.hit = false;
            }
            else if (!direction)
            {
                direction = true;
                localScale.x *= -1;
                hitbox.hit = false;
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPawn playerPawn = collision.collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn == null)
        {
            playerPawn.TakeDamage(null, damage, null, null);

        }
    }
}