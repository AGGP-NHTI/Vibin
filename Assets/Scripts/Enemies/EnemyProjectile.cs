using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public float LT = 5f;

    public bool isElectric = false;
    
    void FixedUpdate()
    {
        gameObject.transform.position += (speed * gameObject.transform.forward * Time.fixedDeltaTime);
        LT -= Time.fixedDeltaTime;
        if (LT <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            playerPawn.TakeDamage(null, damage, null, null);
        }
    }
}
