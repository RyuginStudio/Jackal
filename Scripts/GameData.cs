using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    //=================================角色数据=================================//
    public static float CharacterSpeed = 3;
    public static float TurnSensitivity = 0.05f;  //转向灵敏度
    public static int UpOrDown = 1;  //角色移动动画控制
    public static float bulletCharacMachinGunSpeed = 20;  //角色机枪子弹移速
    public static float bulletCharacMachinGunDistance = 3.5f;  //角色机枪射程


    //=================================敌人数据=================================//
    //1.坦克堡垒
    public static int TankBunkerLifeValue = 100;
    public static float TankBunkerAttackRate = 1; //定时器
    public static float bulletEnemyTankBunkerSpeed = 5;  //坦克堡垒
    public static float bulletEnemyTankBunkerDistance = 5.0f;  //角色机枪射程
}
