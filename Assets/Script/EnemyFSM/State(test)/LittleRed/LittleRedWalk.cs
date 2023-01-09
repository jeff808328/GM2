using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedWalk : LittleRedBaseState
{
    public override void EnterState(LittleRedStateManager StateManager)
    {
        Debug.Log("In Walk");
    }

    public override void UpdateState(LittleRedStateManager StateManager)
    {

    }
}
