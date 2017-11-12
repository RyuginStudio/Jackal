using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBunker : Enemy
{
    private float currentTime;
    private float attackUpdate;
    public GameObject prefabBulletTankBunker;

    // Use this for initialization
    void Start()
    {
        currentTime = Time.time;
        attackUpdate = Time.time;
        init();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        enemyAttack();
    }

    void init()
    {
        this.lifeValue = GameData.TankBunkerLifeValue;
        this.attackRate = GameData.TankBunkerAttackRate;
        this.target = GameObject.FindGameObjectWithTag("Player1");
    }

    public override void enemyAttack()
    {
        if (currentTime - attackUpdate > this.attackRate)
        {
            //Debug.Log("TankBunkerAttack");
            attackAnimation();
            var bulletPrefab = Instantiate(prefabBulletTankBunker, transform.position, Quaternion.Euler(0,0,0));
            bulletPrefab.GetComponent<Bullet>().Shotter = transform.gameObject;  //通过脚本获取物体
            attackUpdate = Time.time;
        }
    }

    public override void attackAnimation()
    {
        //1.炮塔转到角色角度(三角函数)
        //参考：https://jingyan.baidu.com/album/73c3ce280bb9f4e50343d9d1.html?picindex=1
        var thisPos = transform.position;
        var targetPos = target.transform.position;

        var distance_x = thisPos.x - targetPos.x; //对边
        var distance = Vector2.Distance(thisPos, targetPos); //斜边

        var rotationZ = targetPos.y > 0 ? System.Math.Asin(distance_x / distance) / System.Math.PI * 180 + 180 : -System.Math.Asin(distance_x / distance) / System.Math.PI * 180;

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)rotationZ);

        //Debug.Log("炮塔Quatertion: " + transform.rotation);

        // 2.开火炮塔摇摆
        //Debug.Log("TankBunkerAttackAnimation");
        
    }



}
