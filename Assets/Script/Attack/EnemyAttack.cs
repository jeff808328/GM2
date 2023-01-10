using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : CommonAttack
{
    private void Start()
    {
        SetComponent();
    }

    void Update()
    {
        UpdataCollision();
        UpdatePos();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawWireCube(BoxCenter, BoxSize);
    }
}
