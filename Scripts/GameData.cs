//后期放入config配置信息里

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    //=================================角色数据=================================//
    public static float spawnTime = 2.0f;  //重生时间
    public static float CharacterInvincibleTime = 2.0f;  //无敌时间
    public static int CharacterLives = 4;
    public static int MaxPassengerHole = 10;  //最大载客量
    public static float CharacterSpeed = 3;
    public static float TurnSensitivity = 0.04f;  //转向灵敏度
    public static int UpOrDown = 1;  //角色移动动画控制
    public static float bulletCharacMachinGunSpeed = 20;  //角色机枪子弹移速
    public static float bulletCharacMachinGunDistance = 3.8f;  //角色机枪射程
    public static int bulletCharacMachinGunDemage = 40;
    public static float bulletCharacGrenadeSpeed = 6.5f;  //角色手榴弹移速
    public static float bulletCharacGrenadeDistance = 3.5f;  //角色手榴弹射程
    public static int bulletCharacGrenadeDemage = 100;  //手榴弹伤害
    public static float GrenadeColdDown = 1.5f;  //手榴弹投掷冷却时间
    public static float bulletCharacMissileSpeed = 8;  //角色导弹移速
    public static float bulletCharacMissileDistance = 4;  //角色导弹射程
    public static int bulletCharacMissileDemage = 150;  //角色导弹伤害
    public static float CharacMissileColdDown = 1;  //角色导弹冷却时间



    //=================================敌人数据=================================//
    //1.坦克堡垒
    public static int TankBunkerLifeValue = 100;
    public static float TankBunkerAttackRate = 1.9f; //攻击频率定时器
    public static float bulletEnemyTankBunkerSpeed = 5;  //子弹速度
    public static float bulletEnemyTankBunkerDistance = 5.0f;  //射程
    //2.敌人小兵
    public static float soliderSpeed = 0.8f;
    public static float soliderAttackRate = 1.5f;  //攻击频率
    public static float bulletEnemySoliderSpeed = 3;  //子弹速度
    public static float bulletEnemySoliderDistance = 2.0f;  //射程





    //=================================友军数据=================================//
    //1.战友：可被角色（误伤）和敌人杀死
    public static float comradeSpeed = 1;
    public static float comradeInvincibleTime = 1.5f;  //无敌时间
}
