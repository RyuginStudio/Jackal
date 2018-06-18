using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    //单例模式
    private static CharacterAttack instance;
    static public CharacterAttack getInstance()
    {
        return instance;
    }

    //资源加载
    public AudioSource machinGunEffect;
    public AudioSource fireInTheHole;
    public AudioSource missileLaunchEffect;
    public GameObject prefabBulletMachinGun;
    public GameObject prefabBulletGrenade;
    public GameObject prefabBulletMissile;
    private float currentTime;
    private float GrenadeColdDownUpdate;
    private float missileColdDownUpdate;

    Transform trans_BulletsAndExplode;

    public enum weapons  //技能系武器
    {
        grenade,
        missile
    }

    public weapons weaponsHold;

    // Use this for initialization
    void Start()
    {
        instance = this;
        weaponsHold = weapons.grenade;

        trans_BulletsAndExplode = GameObject.FindWithTag("trans_BulletsAndExplode").transform;
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
            var bulletPrefab = Instantiate(prefabBulletMachinGun, transform.position, new Quaternion(0, 0, 0, 0), trans_BulletsAndExplode);
            bulletPrefab.GetComponent<Bullet>().Shotter = transform.gameObject;  //通过脚本获取物体
        }

        if (Input.GetKeyDown(KeyCode.K))  //技能
        {
            if (weaponsHold == weapons.grenade && currentTime - GrenadeColdDownUpdate >= GameData.GrenadeColdDown)  //攻击CD
            {
                GrenadeColdDownUpdate = Time.time;
                fireInTheHole.Play();
                var bulletPrefab = Instantiate(prefabBulletGrenade, transform.position, new Quaternion(0, 0, 0, 0), trans_BulletsAndExplode);
                bulletPrefab.GetComponent<Bullet>().Shotter = transform.gameObject;
            }
            else if (weaponsHold == weapons.missile && currentTime - missileColdDownUpdate >= GameData.CharacMissileColdDown)
            {
                missileColdDownUpdate = Time.time;
                missileLaunchEffect.Play();
                var bulletPrefab = Instantiate(prefabBulletMissile, transform.position, this.transform.localRotation, trans_BulletsAndExplode);
                bulletPrefab.GetComponent<Bullet>().Shotter = transform.gameObject;
            }

        }
    }

    public void firePromote()  //火力提升
    {
        weaponsHold = weapons.missile;
    }
}
