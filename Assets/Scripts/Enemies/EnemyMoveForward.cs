using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : BaseKnight
{   
    public enemyhitbox hitbox;
   
    void Start()
    {
        currentaction = Default;
    }

    void FixedUpdate()
    {
        currentaction();      
    }

    public override void Default()
    {
        transform.localScale = localScale;
        if (direction)
        {
            rb.velocity = new Vector3(1, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(-1, rb.velocity.y, 0);
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
    
}
