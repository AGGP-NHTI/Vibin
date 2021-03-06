﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{

    public JumpState(PlayerPawn pawn) : base(pawn)
    {
    }
    
    public override IEnumerator Update()
    {
        Debug.Log("In State Update");

        _pawn.Anim.SetBool("PlayerGrounded", IsGrounded());
        if (IsGrounded() && _pawn.jumped)
        {
            _pawn.SetState(new IdleState(_pawn));
            _pawn.jumped = false;
        }
        
        if (_pawn.jumpLimit + _pawn.jumpHeight < _pawn.gameObject.transform.position.y)
        {
            _pawn.rb.velocity = new Vector2(_pawn.rb.velocity.x, 0);
        }

        yield break;
    }

    public override IEnumerator HeavyAttack(bool value)
    {
        _pawn.rb.velocity = new Vector2(0, _pawn.SlamSpeed * -1);
        _pawn.AttackLeft.gameObject.SetActive(true);
        _pawn.AttackRight.gameObject.SetActive(true);
        _pawn.invincible = true;
        _pawn.audio.Play();
        yield return new WaitForSeconds(1);
        _pawn.AttackLeft.gameObject.SetActive(false);
        _pawn.AttackRight.gameObject.SetActive(false);
        _pawn.invincible = false;

        yield break;
    }
    public override IEnumerator Walk(float value)
    {

        _pawn.rb.velocity = new Vector2(value * _pawn.walkSpeed , _pawn.rb.velocity.y);

        yield break;
    }

     private bool IsGrounded()
    {
        int layerMask = 1 << 9;
        Debug.Log("Checked for ground");
        return (Physics2D.OverlapArea(_pawn.topLeftOverlap.transform.position, _pawn.bottomRightOverlap.transform.position, layerMask));
    }
    public override IEnumerator Jump(bool value)
    {

        yield break;
    }
}
