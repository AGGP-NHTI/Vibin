using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class State
{
    protected readonly PlayerPawn _pawn;

    public State(PlayerPawn pawn)
    {
        _pawn = pawn;
    }

    public virtual IEnumerator Update()
    {
        Debug.Log("Default State Update");
        yield break;
    }
    public virtual IEnumerator OnStateEnter()
    {

        yield break;
    }
    public virtual IEnumerator Idle()
    {

        yield break;
    }
    public virtual IEnumerator Walk(float value)
    {
        
        yield break;
    }
    public virtual IEnumerator Run(float value)
    {

        yield break;
    }

    public virtual IEnumerator Jump(bool value)
    {

        yield break;
    }

    public virtual IEnumerator LightAttack(bool value)
    {

        yield break;
    }
    public virtual IEnumerator HeavyAttack(bool value)
    {

        yield break;
    }

    public virtual IEnumerator Interact(bool value)
    {

        yield break;
    }
}
