using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : PWPawn
{
    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPawn playerPawn = collision.collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            playerPawn.TakeDamage(null, damage, null, null);

        }
    }
}
