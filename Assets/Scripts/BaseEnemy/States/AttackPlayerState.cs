using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerState : IState
{
    Animator anim;

    public AttackPlayerState(Animator animator)
    {
        anim = animator;
    }

    public void OnEnter()
    {
        //Play animation
        anim.SetTrigger("Attack");
        anim.SetBool("IsAttacking", true);
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        
    }
}
