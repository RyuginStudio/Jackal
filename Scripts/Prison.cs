using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{
    float currentTime;
    float updateHelpUI;

    public bool isDamaged = false;
    public Sprite damagePic; //监狱损坏后图片
    public GameObject prefabExplode; //爆炸预制件
    public GameObject prefabComrade;
    public bool isPromotePrison; //是否为禁锢可升级战友的监狱

    //监狱实例化战友预制件，战友初始状态
    public Comrade.status initStatus;
    public Comrade.direction initDirection;

    Transform trans_BulletsAndExplode;

    //普通监狱相关：
    public GameObject helpUI;
    bool startBlink = false;
    int blinkTimes = 6;
    int normalComradeNums;
    bool doInstantiateNormalComrade;

    // Use this for initialization
    void Start()
    {
        trans_BulletsAndExplode = GameObject.FindWithTag("trans_BulletsAndExplode").transform;

        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        blinkHelpUI();
        instantiateNormalComrade();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDamaged)
        {
            switch (other.tag)
            {
                case "Grenade":
                    {
                        Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                        prisonDamage();
                        break;
                    }

                case "BulletCharacMissile":
                    {
                        Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                        prisonDamage();
                        break;
                    }
            }
        }
    }

    public void prisonDamage()
    {
        if (!isDamaged)
        {
            isDamaged = true;

            updateHelpUI = Time.time + 0.6f;

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
                startBlink = true;
            }
        }
    }

    void blinkHelpUI()
    {
        if (startBlink && currentTime - updateHelpUI > .1f && blinkTimes >= 0)
        {
            updateHelpUI = Time.time;
            if (helpUI.GetComponent<Renderer>().enabled)
            {
                helpUI.GetComponent<Renderer>().enabled = false;
                --blinkTimes;
                if (blinkTimes < 0)
                {
                    normalComradeNums = Random.Range(3, 5);
                    doInstantiateNormalComrade = true;
                }
            }
            else
                helpUI.GetComponent<Renderer>().enabled = true;
        }
    }

    //刷普通战友
    void instantiateNormalComrade()
    {
        if (doInstantiateNormalComrade)
        {
            if (GetComponentsInChildren<Comrade>().Length <= 0 && normalComradeNums > 0)
            {
                --normalComradeNums;
                var comrade = Instantiate(prefabComrade, transform.position, Quaternion.Euler(Vector3.zero), transform);
                comrade.GetComponent<Comrade>().isPromoteComrade = false;
                comrade.transform.localScale = new Vector3(1, 1, 1);
                comrade.GetComponent<Comrade>().admitChangeStatus = false;
                comrade.GetComponent<Comrade>().ComradeStatus = initStatus;
                comrade.GetComponent<Comrade>().ComradeDirec = initDirection;
                StartCoroutine(changePrisonComradeToIdle(comrade));
            }
        }
    }

    IEnumerator changePrisonComradeToIdle(GameObject tempComrade)
    {
        yield return new WaitForSeconds(1.5f);
        if (tempComrade.GetComponent<Comrade>())
        {
            tempComrade.GetComponent<Comrade>().ComradeStatus = Comrade.status.idle;
            tempComrade.GetComponent<Comrade>().animationPlay();

            if (normalComradeNums <= 0)
                Destroy(this);
        }
    }
}