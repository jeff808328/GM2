using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBaseStateManager : MonoBehaviour
{
    #region Component

    [HideInInspector] public EnemyBackGroundData EnemyBackGroundData;
    [HideInInspector] public EnemyMove EnemyMove;
    [HideInInspector] public GroundAndWallDetect GroundAndWallDetect;
    [HideInInspector] public EnemyAttack EnemyAttack;
    [HideInInspector] public CommonAnimator CommonAnimator;
    [HideInInspector] public CommonHP CommonHP;

    #endregion

    #region Value
    [HideInInspector] public int MoveDirection; // 移動朝向

    [HideInInspector] public float LastFlipTime;
    public float FlipCD; // 翻轉間隔 

    [HideInInspector] public float LastAttackTime;
    public float AttackCD; // 攻擊間隔 

    public float StateTransDelay; // Idle進入下個狀態的延遲

    #endregion

    protected void ComponentSetting()
    {
        EnemyBackGroundData = this.GetComponent<EnemyBackGroundData>();
        EnemyMove = this.GetComponent<EnemyMove>();
        GroundAndWallDetect = this.GetComponent<GroundAndWallDetect>();
        EnemyAttack = this.GetComponent<EnemyAttack>();
        CommonAnimator = this.GetComponent<CommonAnimator>();
    }

    protected void InitSetting()
    {
        LastFlipTime = Time.time;
        LastAttackTime = Time.time;
    }

    }
