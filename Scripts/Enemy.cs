using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int lifeValue;
    public float attackRate;
    public int moveSpeed;
	public GameObject target;

	virtual public void enemyAttack()
	{

	}

	virtual public void attackAnimation()
	{

	}

	virtual public void move()
	{

	}

	virtual public void moveAnimation()
	{

	}

}
