using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charger : BaseEnemy
{
    public Vision vision;
    bool charged = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (vision.sighted == true)
        {
            charged = true;
        }
        if (charged)
        {
            charge();
        }
    }
    public void charge()
    {
        rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
    }
}
