//时间：2017年11月19日01:08:19
//作者：VSZED
//用法：挂在到子弹预制件上

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 bulletInitPos;
    public GameObject Shotter;        //发射子弹的人(可以是角色)
    public GameObject target;         //攻击目标
    public Vector3 attackPos;         //通过具体敌人传值
    public Sprite bulletEffect;       //子弹爆炸效果


    // Use this for initialization
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletKind != bullet.bulletCharacMachinGun && bulletKind != bullet.bulletCharacGrenade)
        {
            target = GameObject.FindGameObjectWithTag("Player1");
        }

        bulletTraject();
    }

    void init()
    {
        bulletInitPos = Shotter.transform.position;

        if (bulletKind != bullet.bulletCharacMachinGun && bulletKind != bullet.bulletCharacGrenade)
        {
            target = GameObject.FindGameObjectWithTag("Player1");
        }

    }

    public enum bullet
    {
        bulletCharacMachinGun,
        bulletCharacGrenade,
        bulletEnemyTankBunker,
        bulletEnemyHomingMissile
    }

    public bullet bulletKind;

    void bulletTraject()  //弹道
    {
        switch (bulletKind)
        {
            case bullet.bulletCharacMachinGun:
                {
                    //Debug.Log("bulletCharacMachinGun");
                    float step = GameData.bulletCharacMachinGunSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(bulletInitPos.x, bulletInitPos.y + GameData.bulletCharacMachinGunDistance), step);

                    //以下值均需调用C#取得小数点后1位的四舍五入
                    var initY = System.Math.Round(bulletInitPos.y, 1);
                    var nowY = System.Math.Round(transform.position.y, 1);

                    if (System.Math.Round(nowY - initY, 1) >= GameData.bulletCharacMachinGunDistance)
                    {
                        GetComponent<SpriteRenderer>().sprite = bulletEffect;
                        Invoke("bulletDestroy", 0.1f);
                    }

                    break;
                }

            case bullet.bulletCharacGrenade:
                {
                    //Debug.Log("bulletCharacGrenade");
                    //算法设计：在小车上绑定一个箭头图片，射线的方向为：箭头精灵坐标-小车精灵坐标
                    float step = GameData.bulletCharacGrenadeSpeed * Time.deltaTime;
                    var direction = GameObject.Find("DirectionArrow").transform.position - bulletInitPos;  //================================================修改
                    var shootRay = new Ray2D(bulletInitPos, direction);
                    var pos = shootRay.GetPoint(GameData.bulletCharacGrenadeDistance);
                    transform.position = Vector2.MoveTowards(transform.position, pos, step);

                    break;
                }

            case bullet.bulletEnemyTankBunker:
                {
                    float step = GameData.bulletEnemyTankBunkerSpeed * Time.deltaTime;
                    Vector3 direction = attackPos - bulletInitPos;
                    var bulletRay = new Ray2D(bulletInitPos, direction);
                    Debug.DrawLine(bulletRay.origin, attackPos, Color.red, 0.1f);  //划出射线，在scene视图中能看到由摄像机发射出的射线
                    //参考：http://www.ceeger.com/forum/read.php?tid=4262 
                    //Bug解决：Ray的参数是（起始点，方向向量），不是在两点间画一条线
                    //注意：两点间的方向向量 = 终点 - 起点                        
                    var targetPos = bulletRay.GetPoint(GameData.bulletEnemyTankBunkerDistance);
                    transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

                    if (new Vector2(transform.position.x, transform.position.y) == targetPos)
                    {
                        GetComponent<SpriteRenderer>().sprite = bulletEffect;
                        Invoke("bulletDestroy", 0.1f);
                    }

                    break;
                }

            case bullet.bulletEnemyHomingMissile:  //追踪导弹
                {
                    float step = GameData.bulletEnemyTankBunkerSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                    break;
                }
        }
    }

    void bulletDestroy()  //子弹销毁条件：1.碰撞 2.达到射程
    {
        //Debug.Log("Destroy prefab");
        Destroy(transform.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)  //碰撞检测
    {
        if (bulletKind == bullet.bulletCharacMachinGun)
            return;

        //Debug.Log("bullet collide");
        switch (other.tag)
        {
            case "Player1":
                {
                    bulletDestroy();
                    break;
                }

            default:
                break;
        }
    }
}
