using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPawn : PWPawn
{
    private State _currentState;
    public Rigidbody2D rb;

    public GameObject topLeftOverlap;
    public GameObject bottomRightOverlap;
    public bool jumped;
    public float walkSpeed;
    public float runSpeed;
    public float jumpLimit;
    public float jumpHeight;
    public float jumpSpeed;
    public float gravity;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        SetState(new IdleState(this));
    }

    public void Update()
    {
        Debug.Log(_currentState);
        StartCoroutine(_currentState.Update());
        Gravity();
    }


    public void SetState(State state)
    {
        _currentState = state;
        StartCoroutine(_currentState.OnStateEnter());
    }
    public override void Horizontal(float value)
    {
        StartCoroutine(_currentState.Walk(value));
    }

    public override void Vertical(float value)
    {
        StartCoroutine(_currentState.Jump(value));
    }

    public override void Fire1(bool value)
    {

    }

    public override void Fire2(bool value)
    {

    }

    public void Gravity()
    { 
        //Vector2 gravForce = new Vector2(rb.velocity.x, gravity * -1);


        if (rb.velocity.y < 0)
        {
            Debug.Log("working");
            rb.velocity -= Vector2.up * gravity * 2.5f *Time.deltaTime;
        }

        
    }
}


