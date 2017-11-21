using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comrade : MonoBehaviour
{

    public bool isPromoteComrade;  //可使武器升级的战友
	public AudioSource promoteEffect;  //武器升级音效（只有可升级战友响应）
	public AudioSource comradeEffect;  //战友上车语音（只有可升级战友响应）
	public AudioSource normalComradeEffect;  //普通战友上车声音（只有可升级战友响应）

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
		//Debug.Log("contact with");
		switch (other.tag)
		{
			case "Player1":
			{
				
				break;
			}
			default:
			break;
		}
    }
}
