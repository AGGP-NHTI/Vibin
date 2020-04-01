using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public JumpState(PlayerPawn pawn) : base(pawn)
    {
    }

    public override IEnumerator Walk(float value)
    {

        _pawn.rb.velocity = new Vector2(value * _pawn.walkSpeed , _pawn.rb.velocity.y);

        yield break;
    }
    public override IEnumerator Jump(float value)
    {

        yield break;
    }
}
