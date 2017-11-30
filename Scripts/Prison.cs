using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{

    public Sprite damagePic; //监狱损坏后图片
    public GameObject prefabExplode; //爆炸预制件
    public GameObject prefabComrade;
    public bool isPromotePrison; //是否为禁锢可升级战友的监狱

    //监狱实例化战友预制件，战友初始状态
    public Comrade.status initStatus;
    public Comrade.direction initDirection;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Grenade":
                {
                    Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero));
                    prisonDamage();
                    break;
                }

            case "BulletCharacMissile":
                {
                    Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero));
                    prisonDamage();
                    break;
                }

        }
    }

    public void prisonDamage()
    {
        Destroy(GetComponent<Prison>()); //脚本不会2次触发

        GetComponent<SpriteRenderer>().sprite = damagePic;

        if (isPromotePrison)
        {
            var comrade = Instantiate(prefabComrade, transform.position, Quaternion.Euler(Vector3.zero));
            comrade.GetComponent<Comrade>().isPromoteComrade = true;

            comrade.GetComponent<Comrade>().ComradeStatus = initStatus;
            comrade.GetComponent<Comrade>().ComradeDirec = initDirection;
        }
        else  //非可升级战友
        {
            //TODO:
            for (int i = 0; i < Random.Range(2, 5); i++)  //随机刷一定数量的战友(需要解决视觉重叠->碰撞产生的问题)
            {
                var comrade = Instantiate(prefabComrade, transform.position, Quaternion.Euler(Vector3.zero));
                comrade.GetComponent<Comrade>().isPromoteComrade = false;

                comrade.GetComponent<Comrade>().ComradeStatus = initStatus;
                comrade.GetComponent<Comrade>().ComradeDirec = initDirection;
            }
        }
    }
}