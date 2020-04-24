using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charger : BaseStandardEnemy
{
    public Vision vision;
    public enemyhitbox EnemyHitBox;

   
    void Start()
    {
        slider.maxValue = StartingHealth;
        currentaction = Default;
    }

    
    void FixedUpdate()
    {
        if (vision.sighted == true)
        {
            currentaction = charge;
        }
        
    }
    public void charge()
    {
        rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
        if (EnemyHitBox.bash)
        {
            currentaction = Die;
        }
    }
}
