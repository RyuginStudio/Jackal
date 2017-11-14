using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 bulletInitPos;
    public GameObject PrefabBullet;
    public GameObject Shotter;        //发射子弹的人(可以是角色)
    public GameObject target;         //攻击目标
    public static Vector3 attackPos;  //打哪里(子弹发射时为角色的 => 即时位置，并保持不变)
    public Sprite bulletEffect;       //子弹爆炸效果


    // Use this for initialization
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletKind != bullet.bulletCharacMachinGun)
        {
            target = GameObject.FindGameObjectWithTag("Player1");
        }

        bulletTraject();
    }

    void init()
    {
        bulletInitPos = Shotter.transform.position;

        if (bulletKind != bullet.bulletCharacMachinGun)
        {
            target = GameObject.FindGameObjectWithTag("Player1");
        }

        attackPos = target.transform.position;
    }

    public enum bullet
    {
        bulletCharacMachinGun,
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

            case bullet.bulletEnemyTankBunker:
                {
                    float step = GameData.bulletEnemyTankBunkerSpeed * Time.deltaTime;

                    //子弹未达到射程时，修正attackPos
                    if (Vector3.Distance(attackPos, bulletInitPos) < GameData.bulletEnemyTankBunkerDistance)
                    {
                        //未实现
                    }

                    if (Vector3.Distance(transform.position, bulletInitPos) < GameData.bulletEnemyTankBunkerDistance && transform.position != attackPos)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, attackPos, step);
                    }
                    else
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
        Destroy(PrefabBullet);
    }
}
