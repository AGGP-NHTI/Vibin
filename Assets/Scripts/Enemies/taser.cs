using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taser : EnemyProjectile
{
    public float tazetime = 2f;
    public bool tasing;

    float walkSpeed;
    public GameObject sound;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            tasing = true;
            walkSpeed = playerPawn.walkSpeed;
            playerPawn.walkSpeed = 0;
            sound.SetActive(true);
            playerPawn.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            playerPawn.walkSpeed = walkSpeed;
            playerPawn.rb.constraints = RigidbodyConstraints2D.None;
            playerPawn.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    public override void Move()
    {
        if (!tasing)
        {
            base.Move();
        }
        else
        {
            tazetime -= Time.fixedDeltaTime;
            if (tazetime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
