using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : CommonMove
{
    private EnemyBackGroundData EnemyBackGroundData;

    private EnemyMoveDetect EnemyMoveDetect;

    private AiBaseStateManager EnemyStateManager;

    private void Start()
    {
        SetData();

        SetComponent();

        EnemyBackGroundData = this.GetComponent<EnemyBackGroundData>();
        EnemyMoveDetect = this.GetComponent<EnemyMoveDetect>();


        EnemyStateManager = this.GetComponent<AiBaseStateManager>(); 
    }

    private void Update()
    {
        if (EnemyStateManager.MoveDirection != 0)
            HorizonVelocity(EnemyStateManager.MoveDirection); 
        else
            MiunsSpeed();

        GravityEffect();

        GroundTouching = GroundAndWallDetect.GroundTouching;

        if (GroundTouching)
        {
            VerticalSpeed = Mathf.Clamp(VerticalSpeed, 0, VerticalSpeedMax);
        }

        FinalSpeed = new Vector2(HorizonSpeed, VerticalSpeed);
        Rd.velocity = FinalSpeed;
    }

}
