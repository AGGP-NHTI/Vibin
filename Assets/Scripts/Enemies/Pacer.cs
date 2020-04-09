using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacer : BaseEnemy
{
    public float distance = 2f;
    Vector3 startpos;
    public bool passed = false;
    // Start is called before the first frame update
    void Start()
    {
        startpos = gameObject.transform.position;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
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
}
