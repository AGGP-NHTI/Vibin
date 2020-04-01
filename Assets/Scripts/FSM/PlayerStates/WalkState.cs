using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public WalkState(PlayerPawn pawn) : base(pawn)
    {
    }

    public override IEnumerator Jump(float value)
    {
        if (value > 0)
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
        if(value == 0)
        {
            _pawn.SetState(new IdleState(_pawn));
        }
        _pawn.rb.velocity = new Vector2(value * _pawn.walkSpeed, _pawn.rb.velocity.y);
        yield break;
    }
}
