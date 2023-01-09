using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairStateManager : AiBaseStateManager
{
    #region State

    private LongHairBaseState CurrentState;

    public LongHairIdle Idle = new LongHairIdle();
    public LongHairWalk Walk = new LongHairWalk();
    public LongHairDash Dash = new LongHairDash();
    public LongHairAttack Attack = new LongHairAttack();
    public LongHairSingleThron SingleThron = new LongHairSingleThron();

    public LongHairMultipleThron MultipleThron = new LongHairMultipleThron();
    public LongHairAirUmi AirUmi = new LongHairAirUmi();
    public LongHairGroundUmi GroundUmi = new LongHairGroundUmi();
    public LongHairHurt Hurt = new LongHairHurt();

    #endregion

    #region Value

    [HideInInspector] public float LastThronAttackTime;
    public float ThornAttackCD;

    #endregion

    #region Object

    public GameObject Thron;

    #endregion

    private void Start()
    {
        ComponentSetting();

        InitSetting();

        LastThronAttackTime = Time.time;

        CurrentState = Idle;
        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void StateSwitch(LongHairBaseState NextState)
    {
        CurrentState = NextState;
        
        if(CurrentState != Idle)
        {
            EnterState();
        }
        else
        {
            Invoke("EnterState", StateTransDelay);
        }
    }

    private void EnterState()
    {
        CurrentState.EnterState(this);
    }



}
