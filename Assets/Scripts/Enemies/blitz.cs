using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blitz : MonoBehaviour
{
    float life = 30f;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        life -= Time.fixedDeltaTime;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
