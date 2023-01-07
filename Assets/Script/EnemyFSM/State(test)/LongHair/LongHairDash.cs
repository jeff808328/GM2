using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairDash : LongHairBaseState
{
    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("In Dash");

        StateManager.CommonAnimator.RollTrigger();
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {

    }
}
