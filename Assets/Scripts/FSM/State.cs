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

    public virtual IEnumerator Jump(float value)
    {

        yield break;
    }

    public virtual IEnumerator Attack(bool value)
    {

        yield break;
    }
    public virtual IEnumerator SlamAttack(bool value)
    {

        yield break;
    }
}
