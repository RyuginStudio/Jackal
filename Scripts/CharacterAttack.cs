using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    public AudioSource machinGunEffect;
    public AudioSource fireInTheHole;
    public AudioSource missileLaunchEffect;
    public GameObject prefabBulletMachinGun;
    public GameObject prefabBulletGrenade;
    private float currentTime;
    private float GrenadeColdDownUpdate;

    public enum weapons  //技能系武器
    {
        grenade,
        missile
    }

    public weapons weaponsHold;

    // Use this for initialization
    void Start()
    {
        weaponsHold = weapons.grenade;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        attack();
    }

    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.J))  //普攻
        {
            //Debug.Log("machineGun");
            machinGunEffect.Play();
            var bulletPrefab = Instantiate(prefabBulletMachinGun, transform.position, new Quaternion(0, 0, 0, 0));
            bulletPrefab.GetComponent<Bullet>().Shotter = transform.gameObject;  //通过脚本获取物体
        }

        if (Input.GetKeyDown(KeyCode.K))  //技能
        {
            if (weaponsHold == weapons.grenade && currentTime - GrenadeColdDownUpdate >= GameData.GrenadeColdDown)  //攻击CD
            {
                GrenadeColdDownUpdate = Time.time;
                fireInTheHole.Play();
                var bulletPrefab = Instantiate(prefabBulletGrenade, transform.position, new Quaternion(0, 0, 0, 0));
                bulletPrefab.GetComponent<Bullet>().Shotter = transform.gameObject;
                bulletPrefab.GetComponent<Bullet>().characArrowPos = GameObject.Find("DirectionArrow").transform.position;
            }
            else if (weaponsHold == weapons.missile)
            {
                missileLaunchEffect.Play();
            }

        }
    }
}
