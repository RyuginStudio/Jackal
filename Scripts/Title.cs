using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    private float currentTime;
    private float animationUpdate;
    private float logoAlpha = 0;  //图片alpha值
    private bool choiceBlink = false;  //闪烁动画
    public GameObject carChoicePic;
    public GameObject mask1P;
    public GameObject mask2P;
    public AudioSource[] ExplodeEffect;

    // Use this for initialization
    void Start()
    {
        currentTime = Time.time;
        animationUpdate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        AlpahAnim();
        choice1pOr2p();
        itemBlink();
    }

    void AlpahAnim()
    {
        var TitleColor = GetComponent<SpriteRenderer>().color;

        if (currentTime - animationUpdate >= 0.1f)
        {
            GetComponent<SpriteRenderer>().color = new Color(TitleColor.r, TitleColor.g, TitleColor.b, logoAlpha += 0.02f);
            if (GetComponent<SpriteRenderer>().color.a >= 1)
            {
                carChoicePic.SetActive(true);
            }
        }
    }

    void choice1pOr2p()
    {
        if (Input.GetKeyDown(KeyCode.Return) && GetComponent<SpriteRenderer>().color.a >= 1)
        {
            choiceBlink = true;
            ExplodeEffect[Random.Range(0, 3)].Play();
            Invoke("jumpScene", 2.5f);
        }
    }

    void itemBlink()  //1p、2p选好后闪烁
    {
        if (choiceBlink == true)
        {
            if (currentTime - animationUpdate > 0.2f && currentTime - animationUpdate < 0.4f)
            {
                mask1P.SetActive(true);
            }
            else if (currentTime - animationUpdate > 0.4f)
            {
                mask1P.SetActive(false);
                animationUpdate = Time.time;
            }
        }
    }

    void jumpScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
