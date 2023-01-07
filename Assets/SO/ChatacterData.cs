using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData")]
public class ChatacterData : ScriptableObject
{
    public float MaxMoveSpeed; // 水平最大速度
    public float AddSpeed; // 水平加速度
    public float MinusSpeed; // 水平減速度 

    public float Gravity; // 重力
    public float JumpSpeed; // 垂直最大速度
    public int AirJumpTimes; // 最大跳躍次數

    public float HP; 
    public float Atk;
    public float Def;

    public float AtkCD;
    public float RollCD;
}
