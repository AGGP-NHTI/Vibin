using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : PWPawn
{
    public Vision vision;

    public float idleWidth = 5f;
    public float speed = 2f;

    delegate void currentAction();
    currentAction currentaction;

    Vector3 startpos;
    
    void Start()
    {
        startpos = gameObject.transform.position;
        currentaction = Idle;
    }
   
    void FixedUpdate()
    {
        currentaction();
    }
    void Idle()
    {
        if (vision.sighted == true)
        {
            currentaction = Chase;
            
        }
    }
    void Chase()
    {

    }
    void Attack()
    {
        vision.sighted = false;

    }
    void Hit()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
