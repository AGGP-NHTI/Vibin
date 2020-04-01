using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerPawn pawn) : base(pawn)
    {
    }

    public override IEnumerator Jump(float value)
    {
        if(value > 0)
        {
            _pawn.jumpLimit = _pawn.gameObject.transform.position.y;
            _pawn.rb.velocity = new Vector2(_pawn.rb.velocity.x, _pawn.jumpSpeed);
            _pawn.SetState(new JumpState(_pawn));
            yield return new WaitForSeconds(1);
            _pawn.jumped = true;
        }
        yield break;
    }
    public override IEnumerator Walk(float value)
    {
        if(value > 0 || value < 0)
        {
            _pawn.SetState(new WalkState(_pawn));
        }

        _pawn.rb.velocity = new Vector2(0, _pawn.rb.velocity.y);
        yield break;
    }

    public override IEnumerator Idle()
    {
        return base.Idle();
    }
}
