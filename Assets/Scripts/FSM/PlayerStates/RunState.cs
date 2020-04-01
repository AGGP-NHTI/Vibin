using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    public RunState(PlayerPawn pawn) : base(pawn)
    {
    }

    public override IEnumerator Jump(float value)
    {
        if (value > 0)
        {
            _pawn.SetState(new JumpState(_pawn));

        }
        yield break;
    }

    public override IEnumerator Run(float value)
    {
        return base.Run(value);
    }
}
