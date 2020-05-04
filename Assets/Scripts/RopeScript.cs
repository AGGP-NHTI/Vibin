using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerPawn>())
        {
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
