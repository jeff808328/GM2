using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairAirUmi : LongHairBaseState
{
    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("Air Umi Triggered");

        // �_��
        // �ͦ�������
        // ���
        
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {
        FlipCheck(StateManager);
        //�p��
        StateManager.StateSwitch(StateManager.Idle);//�������A
    }
}
