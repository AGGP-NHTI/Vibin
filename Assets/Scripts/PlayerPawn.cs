using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPawn : PWPawn
{
    private State _currentState;
    public Rigidbody2D rb;
    public Animator Anim;

    public GameObject AttackRight;
    public GameObject AttackLeft;
    public GameObject topLeftOverlap;
    public GameObject bottomRightOverlap;
    public float SlamSpeed;
    public bool jumped;
    public float walkSpeed;
    public float runSpeed;
    public float jumpLimit;
    public float jumpHeight;
    public float jumpSpeed;
    public float gravity;
    public bool InFrontOfRope;
    public float ropeXPosition;
    public bool attacking;
    public float knockback;

    public float health = 3;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        SetState(new IdleState(this));
    }

    public void Update()
    {
        Debug.Log(_currentState);
        StartCoroutine(_currentState.Update());
        Anim.SetFloat("PlayerJumpVelocity", rb.velocity.y);
        Anim.SetFloat("Horizontal", rb.velocity.x);
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

    public override void Vertical(bool value)
    {
        StartCoroutine(_currentState.Jump(value));
    }

    public override void Fire1(bool value)
    {
        StartCoroutine(_currentState.LightAttack(value));
    }

    public override void Fire2(bool value)
    {
        StartCoroutine(_currentState.HeavyAttack(value));
    }

    public override void Interact(bool value)
    {
        StartCoroutine(_currentState.Interact(value));
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

    public void Damage(Vector3 KBdirection)
    {
        Debug.Log("knockback direction: " + KBdirection.x);
        Debug.Log("I got hit by an AI");

        health -= 1;
    }
}


