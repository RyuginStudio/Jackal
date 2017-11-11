using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBunker : Enemy
{
    private float currentTime;
    private float attackUpdate;

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

        var rotation = targetPos.y > 0 ? System.Math.Asin(distance_x / distance) / 3.14 * 180 + 180 : -System.Math.Asin(distance_x / distance) / 3.14 * 180;
        //Debug.Log(rotation);

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)rotation);

        // 2.开火炮塔摇摆
        //Debug.Log("TankBunkerAttackAnimation");
        
    }



}
