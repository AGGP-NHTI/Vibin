using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    float position;
    private void Start()
    {
        position = transform.position.x + 0.5f;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerPawn>())
        {
            collision.gameObject.GetComponent<PlayerPawn>().ropeXPosition = position;
            collision.gameObject.GetComponent<PlayerPawn>().InFrontOfRope = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerPawn>())
        {
            collision.gameObject.GetComponent<PlayerPawn>().InFrontOfRope = false;
        }
    }

}
