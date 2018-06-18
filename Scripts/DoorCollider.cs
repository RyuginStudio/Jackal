/*
 * 时间：2018年6月18日11:43:18
 * 作者：vszed
 * 功能：门型障碍物
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public GameObject openStatus;
    public GameObject closeStatus;

    //爆炸预制体
    public GameObject prefabExplode;
    //存放预制体容器
    private Transform trans_BulletsAndExplode;

    // Use this for initialization
    void Start()
    {
        trans_BulletsAndExplode = GameObject.FindWithTag("trans_BulletsAndExplode").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "BulletCharacMissile":
                {
                    Destroy(collision.gameObject);
                    Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                    Destroy(gameObject);
                    break;
                }
            case "Grenade":
                {
                    Instantiate(prefabExplode, collision.transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                    Destroy(collision.gameObject);
                    Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                    Destroy(gameObject);
                    break;
                }
            default:
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "BulletCharacMissile":
                {
                    Destroy(collision.gameObject);
                    Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                    Destroy(gameObject);
                    break;
                }
            case "Grenade":
                {
                    Instantiate(prefabExplode, collision.transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                    Destroy(collision.gameObject);
                    Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
                    Destroy(gameObject);
                    break;
                }
            default:
                break;
        }
    }
}
