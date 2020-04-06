using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : PWPawn
{
    public GameObject vision;
    public float idleWidth = 5f;
    public float speed = 2f;
    delegate void currentAction();
    currentAction currentaction;

    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = gameObject.transform.position;
        currentaction = Idle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentaction();
    }
    void Idle()
    {

    }
    void Chase()
    {

    }
    void Attack()
    {
        
    }
}
