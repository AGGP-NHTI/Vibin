using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public float LT = 5f;
    public bool penetrate = false;
    public bool destructable = false;
    
    void FixedUpdate()
    {
        Move();
        if (LT <= 0)
        {
            Destroy(gameObject);
        }
    }
    public virtual void Move()
    {
        gameObject.transform.position += (-speed * gameObject.transform.right * Time.fixedDeltaTime);
        LT -= Time.fixedDeltaTime;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        PlayerAttackDamageLeft PL = collider.GetComponent(typeof(PlayerAttackDamageLeft)) as PlayerAttackDamageLeft;
        PlayerAttackDamage PR = collider.GetComponent(typeof(PlayerAttackDamage)) as PlayerAttackDamage;
        if (playerPawn != null)
        {
            playerPawn.Damage(gameObject.transform.right);
            if (!penetrate)
            {
                Destroy(gameObject);
            }
        }
        if (PL != null || PR != null)
        {
            Destroy(gameObject);
        }
    }
}
