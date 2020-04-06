using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : PWPawn
{
    public Vision vision;

    Vector3 localScale;
    public float idleWidth = 5f;
    public float speed = 2f;
    public float AT = 1f;

    bool movingRight = true;
    delegate void currentAction();
    currentAction currentaction;

    Vector3 startpos;
    
    void Start()
    {
        startpos = gameObject.transform.position;
        currentaction = Idle;
        localScale = transform.localScale;
    }
   
    void FixedUpdate()
    {
        currentaction();
        transform.localScale = localScale;
    }
    void Moving()
    {
        if (movingRight)
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        else
        {
            gameObject.transform.position += new Vector3(-speed, 0, 0);
        }
    }
    void Idle()
    {
        Moving();
        if (gameObject.transform.position.x > startpos.x)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }
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
        

    }
    void Hit()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
