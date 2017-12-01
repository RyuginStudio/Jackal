/*
时间：2017年11月18日05:14:38
作者：VSZED
功能：一些不好实现的功能，统一放到这里进行处理
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    private float currentTime;
    public GameObject CharacPrefab;
    public int CharacterLives;
    private Vector3 spawnPoint;
    public static float temp_Alpha = 0;  //alpha值
    private float maskUpdate;  //画面渐变定时器
    public bool doChange = false;  //执行渐变


    private static GameControler instance;
    public static GameControler getInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        currentTime = Time.time;

        CharacterLives = GameData.CharacterLives;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        gradualChange();
    }

    public void characSpawn(Vector3 spawnPoint)
    {
        //Debug.Log("characSpawn");
        if (CharacterLives > 0)
        {
            this.spawnPoint = spawnPoint;
            Invoke("InstantiatePrefab", GameData.spawnTime);
        }
    }

    public void InstantiatePrefab()
    {
        //加判断预防同时碰撞生成两个预制件，生命递减在这也一样
        if (GameObject.FindGameObjectWithTag("Player1") == null)
        {
            --GameControler.getInstance().CharacterLives;
            Instantiate(CharacPrefab, spawnPoint, Quaternion.Euler(Vector3.zero));
        }
    }

    public void gradualChange()  //画面渐变
    {
        if (doChange & currentTime - maskUpdate > 0.05) //"短路"计算
        {
            maskUpdate = Time.time;

            GameObject.FindGameObjectWithTag("Mask").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, temp_Alpha);

            if (temp_Alpha < 1)
            {
                temp_Alpha += 0.05f;
            }
        }
    }

    public void gameRestart()  //游戏重开：重读LOGO
    {
        SceneManager.LoadScene("LogoScene");
    }
}
