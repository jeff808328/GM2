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
    [HideInInspector] public int MoveDirection; // ���ʴ¦V

    [HideInInspector] public float LastFlipTime;
    public float FlipCD; // ½�ඡ�j 

    [HideInInspector] public float LastAttackTime;
    public float AttackCD; // �������j 

    public float StateTransDelay; // Idle�i�J�U�Ӫ��A������

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
