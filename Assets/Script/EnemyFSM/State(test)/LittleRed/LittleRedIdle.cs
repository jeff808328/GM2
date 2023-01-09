using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedIdle : LittleRedBaseState
{
    public override void EnterState(LittleRedStateManager StateManager)
    {
        Debug.Log("In Idle");
    }

    public override void UpdateState(LittleRedStateManager StateManager)
    {

    }
}
