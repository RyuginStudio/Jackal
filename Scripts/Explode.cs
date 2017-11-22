/*
*时间：2017年11月18日04:24:47
*作者：VSZED
*功能：爆炸碰撞及音效
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public AudioSource[] ExplodeEffect;

    // Use this for initialization
    void Start()
    {
        playExplodeEffect();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playExplodeEffect()
    {
        var randValue = Random.Range(0, 5);
        ExplodeEffect[randValue].Play();
        Invoke("destroyPrefab", ExplodeEffect[randValue].clip.length / 2);
    }

    public void destroyPrefab()
    {
        Destroy(gameObject);
    }

}