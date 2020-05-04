using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamageLeft : MonoBehaviour
{
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

        if (enemy)
        {
            enemy.Damage(false);
        }
    }


}
