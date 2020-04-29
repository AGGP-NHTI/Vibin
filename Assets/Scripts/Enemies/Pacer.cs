using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacer : BaseKnight
{
    public float distance = 2f;
    Vector3 startpos;
    public bool passed = false;
    
    void Start()
    {
        slider.maxValue = StartingHealth;
        startpos = gameObject.transform.position;
        localScale = transform.localScale;
        currentaction = Default;
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        transform.localScale = localScale;
        currentaction();
        if (sight.hit)
        {
            currentaction = Attack;
        }

    }
    public override void Default()
    {
        if (direction)
        {
            rb.velocity = new Vector3(1, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(-1, rb.velocity.y, 0);
        }
        if (Vector3.Distance(gameObject.transform.position, startpos) > distance && passed)
        {
            localScale.x *= -1;
            if (direction)
            {
                direction = false;
                passed = false;

            }
            else if (!direction)
            {
                direction = true;
                passed = false;

            }
        }
        if (Vector3.Distance(gameObject.transform.position, startpos) < (distance / 2))
        {
            passed = true;
        }
        

    }
    public override void Recoil()
    {
        base.Recoil();
        if (groundcheck.bash)
        {
            startpos = gameObject.transform.position;
        }
    }
}
