using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhitbox : MonoBehaviour
{
    public bool hit = false;
    public bool bash = false;

    public bool damaging = false;
    public BaseEnemy baseEnemy;

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            hit = true;
            if (damaging)
            {
                playerPawn.Damage(baseEnemy.gameObject.transform.right);
            }
        }
        else
        {
            bash = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            hit = false;

        }
        else
        {
            bash = false;
        }
    }
}
