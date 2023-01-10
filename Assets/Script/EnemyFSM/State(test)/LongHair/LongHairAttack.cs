using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairAttack : LongHairBaseState
{
    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("In Attack");

        StateManager.CommonAnimator.AttackTrigger();

        StateManager.EnemyAttack.Attack();

        StateManager.EnemyMove.CallBrake(0.5f);

        StateManager.LastAttackTime = Time.time;

        StateManager.StateSwitch(StateManager.Idle);
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {

    }
}
