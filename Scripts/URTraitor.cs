//时间：2017年11月30日22:42:10
//作者：VSZED
//功能：击杀n个（取配表）及以上战友，显示“你是祖国的叛徒” => 利用遮罩和文字图片实现

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URTraitor : MonoBehaviour
{
    private float currentTime;
    private float displayURTraitorUpdate;
    private static URTraitor instance;
    public int kill_Comrade_Num = 0;
    public bool do_Change = false;  //label执行渐变与否
    private float temp_alpha = 0;

    void Start()
    {
        instance = this;

        currentTime = Time.time;
        displayURTraitorUpdate = Time.time;
    }

    void Update()
    {
        displayURTraitor();
    }

    public static URTraitor getInstance()
    {
        return instance;
    }

    public void URTraitorOrNot()
    {
        ++kill_Comrade_Num;

        if (kill_Comrade_Num >= GameData.killComradeMaxNum)
        {
			//TODO:需要声音淡出功能

            GameControler.getInstance().doChange = true;  //执行渐变	
            Invoke("changeStatus", 1.5f);
        }
    }

    void changeStatus()
    {
        do_Change = true;
    }

    public void displayURTraitor()
    {
        //Debug.Log("你是祖国的叛徒");

        currentTime = Time.time;

        if (do_Change & currentTime - displayURTraitorUpdate > 0.05)
        {
            displayURTraitorUpdate = Time.time;
            GameObject.FindGameObjectWithTag("Label_URTraitor").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, temp_alpha);

            if (temp_alpha <= 1)
            {
                temp_alpha += 0.05f;
            }
            else
            {
                this.do_Change = false;
                Invoke("doRestart", 2);
            }
        }
    }

	public void doRestart()
	{
		//不考虑剩余命数直接重开
		GameControler.getInstance().gameRestart();
	}

}