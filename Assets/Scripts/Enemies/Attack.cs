using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 1f;
    public float LT = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

        }
    }
}
