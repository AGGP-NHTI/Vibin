using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseStandardEnemy enemy = collision.gameObject.GetComponent<BaseStandardEnemy>();

        if(enemy)
        {
            enemy.Damage(true);
        }
        else if(collision.gameObject.GetComponent<BaseEnemy>())
        {
            collision.gameObject.GetComponent<BaseEnemy>().Damage(true);
        }
    }
}
