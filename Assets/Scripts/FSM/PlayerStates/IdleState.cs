﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(PlayerPawn pawn) : base(pawn)
    {
    }

    public override IEnumerator Jump(bool value)
    {
        if(value)
        {
            _pawn.jumpLimit = _pawn.gameObject.transform.position.y;
            _pawn.rb.velocity = new Vector2(_pawn.rb.velocity.x, _pawn.jumpSpeed);
            _pawn.SetState(new JumpState(_pawn));
            yield return new WaitForSeconds(1);
            _pawn.jumped = true;
        }
        yield break;
    }
    public override IEnumerator LightAttack(bool value)
    {
        if (value)
        {

            if (_pawn.Anim.GetCurrentAnimatorStateInfo(0).IsName("IdleLeftAnimation") && !_pawn.attacking)
            {
                _pawn.Anim.SetBool("PlayerAttacked", value);
                _pawn.attacking = true;
                _pawn.AttackLeft.gameObject.SetActive(true);
                _pawn.rb.constraints = RigidbodyConstraints2D.FreezeAll;
                _pawn.audio.Play();
                yield return new WaitForSeconds(0.2f);
                _pawn.AttackLeft.gameObject.SetActive(false);
                _pawn.Anim.SetBool("PlayerAttacked", false);
                _pawn.attacking = false;
                _pawn.rb.constraints = RigidbodyConstraints2D.FreezeRotation;


            }
            else
            {
                if (!_pawn.attacking)
                {
                    _pawn.Anim.SetBool("PlayerAttacked", value);
                    _pawn.AttackRight.gameObject.SetActive(true);
                    _pawn.attacking = true;
                    _pawn.rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    _pawn.audio.Play();
                    yield return new WaitForSeconds(0.2f);
                    _pawn.AttackRight.gameObject.SetActive(false);
                    _pawn.attacking = false;
                    _pawn.Anim.SetBool("PlayerAttacked", false);
                    _pawn.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
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

    public override IEnumerator Interact(bool value)
    {
        if(_pawn.InFrontOfRope)
        {
            _pawn.gameObject.transform.position = new Vector3(_pawn.ropeXPosition, _pawn.transform.position.y, 0);
            _pawn.SetState(new ClimbingState(_pawn));
        }
        yield break;
    }

    public override IEnumerator Idle()
    {
        return base.Idle();
    }
}
