using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedStateManager :  AiBaseStateManager
{
    #region State

    private LittleRedBaseState CurrentState;

    public LittleRedIdle Idle;
    public LittleRedAttack Attack;
    public LittleRedWalk Walk;
    public LittleRedKick Kick;
    public LittleRedDash Dash;

    public LittleRedHurt Hurt;


    #endregion

    void Start()
    {
        ComponentSetting();

        InitSetting();

        CurrentState = Idle;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void StateSwitch(LittleRedBaseState NextState)
    {
        CurrentState = NextState;

        if(NextState == Idle)
        {
            Invoke("EnterState", StateTransDelay);
        }
        else
        {
            EnterState();
        }
    }

    private void EnterState()
    {
        CurrentState.EnterState(this);
    }
}
