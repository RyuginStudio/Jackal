/*
*时间：2017年11月18日02:12:54
*功能：动画播放
*作者：VSZED
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public List<Sprite> AnimationFrames;
    public int FramesIdx;
    public int RepeatIdx;  //二次循环起始图
    public bool RepeatOrNot;
    public float ScheduleUpdate;
    public float CurrentTime;
    public float DeltaTime;
    public bool autoPlay;
    public bool attackAnimation;
    public string Tag;  //区分多个脚本

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (autoPlay == true)
        {
            play();
        }
    }

    public void play()
    {
        CurrentTime = Time.time;

        if (CurrentTime - ScheduleUpdate > DeltaTime)
        {
            ScheduleUpdate = Time.time;

            this.GetComponent<SpriteRenderer>().sprite = AnimationFrames[FramesIdx];

            if (FramesIdx < AnimationFrames.Count - 1)
            {
                ++FramesIdx;
            }
            else if(RepeatOrNot == true)
            {
                FramesIdx = RepeatIdx;
            }
        }

    }

}
