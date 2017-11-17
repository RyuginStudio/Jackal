/*
时间：2017年11月18日05:14:38
作者：VSZED
功能：一些不好实现的功能，统一放到这里进行处理
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public GameObject CharacPrefab;
    public int CharacterLives;
    private Vector3 spawnPoint;

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
        CharacterLives = GameData.CharacterLives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void characSpawn(Vector3 spawnPoint)
    {
        //Debug.Log("characSpawn");
        if (CharacterLives >= 0)
        {
            this.spawnPoint = spawnPoint;
            Invoke("InstantiatePrefab", GameData.spawnTime);
        }
    }

    public void InstantiatePrefab()
    {
        Instantiate(CharacPrefab, spawnPoint, Quaternion.Euler(Vector3.zero));
    }
}
