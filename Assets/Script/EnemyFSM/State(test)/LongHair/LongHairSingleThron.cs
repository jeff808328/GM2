using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairSingleThron : LongHairBaseState
{
    private float FirstScanTime;
    private float LastScanTime;

    private Transform PlayerPos;
    private Vector3 GeneratePoint;


    public override void EnterState(LongHairStateManager StateManager)
    {
        Debug.Log("In Single Thron");

        StateManager.LastThronAttackTime = Time.time;
    }

    public override void UpdateState(LongHairStateManager StateManager)
    {
        PlayerPos = StateManager.EnemyBackGroundData.PlayerPos;

        GeneratePoint = new Vector3(PlayerPos.transform.position.x, PlayerPos.transform.position.y - 0.5f, 0);

        MonoBehaviour.Instantiate(StateManager.Thron, GeneratePoint, Quaternion.identity);

        StateManager.StateSwitch(StateManager.Idle);
    }
}
