using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LittleRedBaseState 
{
    private float HpNow;
    private float HpFull;

    public abstract void EnterState(LittleRedStateManager StateManager);

    public abstract void UpdateState(LittleRedStateManager StateManager);

    protected void FlipCheck(LittleRedStateManager StateManager)
    {
        if (!StateManager.EnemyBackGroundData.FacePlayer && Time.time > StateManager.LastFlipTime + StateManager.FlipCD)
        {
            Debug.Log("filp");

            StateManager.EnemyMove.HorizonFlip();

            StateManager.LastFlipTime = Time.time;
        }
    }

    protected void AttackCheck(LittleRedStateManager StateManager)
    {
        if (StateManager.EnemyBackGroundData.AttackAble & StateManager.LastAttackTime + StateManager.AttackCD < Time.time)
        {
           // StateManager.StateSwitch(StateManager.Attack);
        }
    }
}
