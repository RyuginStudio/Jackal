using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	Vector3 bulletInitPos; 

    // Use this for initialization
    void Start()
    {
		bulletInitPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTraject();
    }

    public enum bullet
    {
        bulletCharacMachinGun,
    }

    public bullet bulletKind;

    void bulletTraject()  //弹道
    {
        switch (bulletKind)
        {
            case bullet.bulletCharacMachinGun:
                {
                    //Debug.Log("bulletCharacMachinGun");
                    float step = GameData.bulletCharacMachinGunSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(bulletInitPos.x, bulletInitPos.y + GameData.bulletCharacMachinGunDistance), step);
                    break;
                }

        }
    }

	void bulletRemove()  //子弹销毁条件：1.碰撞 2.达到射程
	{

	}
}
