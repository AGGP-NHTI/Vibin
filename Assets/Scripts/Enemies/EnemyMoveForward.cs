using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : BaseKnight
{   
    public enemyhitbox hitbox;
   
    void Start()
    {
        slider.maxValue = StartingHealth;
        currentaction = Default;
        timeleft = attacktime;
        sword.transform.gameObject.SetActive(false);
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        currentaction();
        if (attacked)
        {
            currentaction = Recoil;
        }
        if (sight.hit)
        {
            if (currentaction != Recoil)
            {
                currentaction = Attack;
            }
        }
        HitCheck();
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
        if (hitbox.bash == true)
        {
            if (direction)
            {
                direction = false;
                localScale.x *= -1;
                hitbox.bash = false;
            }
            else if (!direction)
            {
                direction = true;
                localScale.x *= -1;
                hitbox.bash = false;
            }

        }
    }
    
}
