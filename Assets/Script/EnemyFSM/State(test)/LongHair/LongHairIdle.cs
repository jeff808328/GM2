using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairIdle : LongHairBaseState
{
    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("In Idle");
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {
        FlipCheck(StateManager);

        AnyStateTrigger(StateManager);

        ActionSwitch(StateManager);
    }

    private void ActionSwitch(LongHairStateManager StateManager)
    {
        if (StateManager.EnemyBackGroundData.FacePlayer)
        {
            switch (StateManager.EnemyBackGroundData.ActionIndex)
            {
                case 0:
                    {
                        StateManager.StateSwitch(StateManager.Walk);
                        break;
                    }
                case 1:
                    {
                        StateManager.StateSwitch(StateManager.Dash);
                        break;
                    }
                case 2:
                    {
                        if (Time.time > StateManager.LastThronAttackTime + StateManager.ThornAttackCD)
                        {
                            StateManager.StateSwitch(StateManager.SingleThron);
                        }

                        break;
                    }
            }
        }
    }

}
