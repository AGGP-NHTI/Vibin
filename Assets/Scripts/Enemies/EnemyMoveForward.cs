using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : BaseEnemy
{
    Rigidbody2D rb;
    bool direction = false;

    public enemyhitbox hitbox;
    void FixedUpdate()
    {
        if (direction)
        {
            Vector3 location = rb.position;

            location += (speed * 1 * Time.fixedDeltaTime * transform.forward);

            rb.position = location;
        }
        else
        {
            Vector3 location = rb.position;

            location += (speed * -1 * Time.fixedDeltaTime * transform.forward);

            rb.position = location;
        }
        if (hitbox.hit == true)
        {
            if (direction)
            {
                direction = false;
            }
            else if (!direction)
            {
                direction = true;
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
