using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearts : MonoBehaviour
{
    public bool go = false;
    public float rate = 5f;
    
    
    void Update()
    {
        if (go)
        {
            transform.localScale -= new Vector3(rate, rate, rate) * Time.fixedDeltaTime;
            
            if (transform.localScale.x <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Vanish()
    {
        go = true;
    }
}
