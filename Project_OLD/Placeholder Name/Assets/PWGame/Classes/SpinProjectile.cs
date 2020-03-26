using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinProjectile : Projectile
{
    public int rotateSpeed;
    void Update()
    {
        gameObject.transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);
    }
}
