using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    //=================================角色数据=================================//
    public static float spawnTime = 2.0f;  //重生时间
    public static float invincibleTime = 2.0f;  //无敌时间
    public static int CharacterLives = 4;
    public static float CharacterSpeed = 3;
    public static float TurnSensitivity = 0.05f;  //转向灵敏度
    public static int UpOrDown = 1;  //角色移动动画控制
    public static float bulletCharacMachinGunSpeed = 20;  //角色机枪子弹移速
    public static float bulletCharacMachinGunDistance = 3.8f;  //角色机枪射程
    public static float bulletCharacGrenadeSpeed = 5;  //角色手榴弹移速
    public static float bulletCharacGrenadeDistance = 3.5f;  //角色手榴弹射程


    //=================================敌人数据=================================//
    //1.坦克堡垒
    public static int TankBunkerLifeValue = 100;
    public static float TankBunkerAttackRate = 1.9f; //攻击频率定时器
    public static float bulletEnemyTankBunkerSpeed = 5;  //子弹速度
    public static float bulletEnemyTankBunkerDistance = 5.0f;  //角色机枪射程
}
