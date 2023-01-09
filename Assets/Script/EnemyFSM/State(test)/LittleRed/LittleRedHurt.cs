using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedHurt : LittleRedBaseState
{
    public override void EnterState(LittleRedStateManager StateManager)
    {
        Debug.Log("In Hurt");
    }

    public override void UpdateState(LittleRedStateManager StateManager)
    {

    }
}
