using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public bool sighted = false;

    void Start()
    {
        bool sighted = false;
    }            
    
    void Update()
    {
        
    }
    OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            sighted = true;
        }
    }
}

