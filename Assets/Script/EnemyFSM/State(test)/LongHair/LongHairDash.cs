using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairDash : LongHairBaseState
{
    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("In Dash");

        StateManager.CommonAnimator.RollTrigger();

        StateManager.EnemyMove.CallDash(StateManager.MoveDirection, 0.5f);
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {
        if(StateManager.EnemyBackGroundData.AttackAble)
        {
            StateManager.StateSwitch(StateManager.Attack);
        }

        if (!StateManager.EnemyMove.Dashing)
        {
            StateManager.StateSwitch(StateManager.Walk);
        }
    }
}
