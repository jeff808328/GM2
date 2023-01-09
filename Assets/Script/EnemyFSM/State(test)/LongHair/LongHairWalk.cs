using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairWalk : LongHairBaseState
{
    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("In Walk");
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {
        FlipCheck(StateManager);

        AnyStateTrigger(StateManager);

        AttackCheck(StateManager);

        StateManager.MoveDirection = StateManager.EnemyBackGroundData.PlayerDirection;

        // �L�@�w�ɶ���n�^idle
    }
}
