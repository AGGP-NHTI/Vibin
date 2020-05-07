using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratrack : MonoBehaviour
{
    public GameObject target;
    public float distance = 5f;
    public float speed = 5f;


    void Awake()
    {
        gameObject.transform.SetParent(null);
    }

    
    void Update()
    {
        if (target.transform.position.x > gameObject.transform.position.x - distance)
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (target.transform.position.x < gameObject.transform.position.x + distance)
        {
            gameObject.transform.position += new Vector3(-speed, 0, 0);
        }
        if (target.transform.position.y > gameObject.transform.position.y - distance)
        {
            gameObject.transform.position += new Vector3(0, speed, 0);
        }
        if (target.transform.position.y < gameObject.transform.position.y + distance)
        {
            gameObject.transform.position += new Vector3(0, -speed, 0);
        }
    }
}
