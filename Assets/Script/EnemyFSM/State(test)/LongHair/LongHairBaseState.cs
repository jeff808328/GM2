using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LongHairBaseState
{
    private float HpNow;
    private float HpFull;

    public abstract void EnterState(LongHairStateManager StateManager);

    public abstract void UpdateState(LongHairStateManager StateManager);

    protected void FlipCheck(LongHairStateManager StateManager)
    {


        if (!StateManager.EnemyBackGroundData.FacePlayer && Time.time > StateManager.LastFlipTime + StateManager.FlipCD)
        {
            Debug.Log("filp");

            StateManager.EnemyMove.HorizonFlip();

            StateManager.LastFlipTime = Time.time;
        }
    }

    protected void AttackCheck(LongHairStateManager StateManager)
    {
        if (StateManager.EnemyBackGroundData.AttackAble & StateManager.LastAttackTime + StateManager.AttackCD < Time.time)
        {
            StateManager.StateSwitch(StateManager.Attack);
        }
    }

    protected void AnyStateTrigger(LongHairStateManager StateManager)
    {

        //HpFull = StateManager.CommonHP.ChatacterData.HP;
        //HpNow = StateManager.CommonHP.HP;

        //if(HpNow <= HpFull*(1 - 0.25f * StateManager.SkillUsedTime))
        //{

        //}

        if (StateManager.EnemyBackGroundData.AirAttackAble)
        {
            StateManager.StateSwitch(StateManager.GroundUmi);
        }

        if (StateManager.EnemyBackGroundData.Nearing && !StateManager.EnemyBackGroundData.PlayerGroundTouching)
        {
            StateManager.StateSwitch(StateManager.AirUmi);
        }
    }
}
