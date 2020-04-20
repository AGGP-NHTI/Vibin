using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float RotationRate = 50f;
    
    void FixedUpdate()
    {
        gameObject.transform.Rotate(-RotationRate * Time.fixedDeltaTime * Vector3.forward);
    }
}
