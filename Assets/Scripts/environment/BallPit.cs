using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPit : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {

        }

        BaseStandardEnemy basestandardEnemy = collider.GetComponent(typeof(BaseStandardEnemy)) as BaseStandardEnemy;
        if (basestandardEnemy != null)
        {
            basestandardEnemy.currentaction = basestandardEnemy.Die;
            basestandardEnemy.Health = 0;
        }
    }
}
