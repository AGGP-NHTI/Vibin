using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPawn : PWPawn
{
    Rigidbody rb;

    public GameObject bulletSpawn;

    int index;
    public float rotateSpeed;
    public float speed;
    public List<GameObject> projectiles;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Horizontal(float value)
    {
        gameObject.transform.Rotate(value * rotateSpeed * Time.deltaTime * Vector3.up);
    }

    public override void Vertical(float value)
    {
        rb.velocity = value * transform.forward * speed;
    }

    public override void Fire1(bool value)
    {
        if (value)
        {
            Info.Factory(projectiles[index], bulletSpawn.transform.position,transform.rotation, controller);
        }
        
    }

    public override void Fire2(bool value)
    {
        if (index == 3)
        {
            index = 0;
        }
        else index++;



    }

    public override void Fire3(bool value)
    {
        if (index == 0)
        {
            index = 3;
        }
        else index--;
    }


}
