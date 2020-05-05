﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : State
{
    public ClimbingState(PlayerPawn pawn) : base(pawn)
    {
    }

    public override IEnumerator Jump(bool value)
    {
        if (value)
        {
            _pawn.jumpLimit = _pawn.gameObject.transform.position.y;
            _pawn.rb.velocity = new Vector2(_pawn.rb.velocity.x, _pawn.jumpSpeed);
            _pawn.SetState(new JumpState(_pawn));
            yield return new WaitForSeconds(0.1f);
            _pawn.jumped = true;
        }
        yield break;
    }

    public override IEnumerator Walk(float value)
    {
        _pawn.rb.velocity = new Vector2(0,value * 4);
        yield break;
    }

}
