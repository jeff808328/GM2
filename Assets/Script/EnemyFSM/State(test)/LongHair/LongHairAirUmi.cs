using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairAirUmi : LongHairBaseState
{
    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("Air Umi Triggered");

        // 起跳
        // 生成打擊塊
        // 凌空
        
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {
        FlipCheck(StateManager);
        //計時
        StateManager.StateSwitch(StateManager.Idle);//切換狀態
    }
}
