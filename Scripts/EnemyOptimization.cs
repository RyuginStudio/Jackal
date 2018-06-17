/*
 * 时间：2018年6月17日15:04:22
 * 作者：vszed
 * 功能：优化摄像机内看不到的敌人
 * 用法：挂载到敌人父物体下
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOptimization : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        switch (gameObject.tag)
        {
            case "TankBunker":
                {
                    GetComponent<TankBunker>().enabled = false;
                    break;
                }
        }
    }

    private void OnBecameVisible()
    {
        switch (gameObject.tag)
        {
            case "TankBunker":
                {
                    GetComponent<TankBunker>().enabled = true;
                    break;
                }
        }
    }
}
