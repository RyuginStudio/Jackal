using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public AudioSource vszed;
    private float currentTime;
    private float animationUpdate;
    private float logoAlpha = 0;  //图片alpha值

    // Use this for initialization
    void Start()
    {
        Invoke("playSound", 0.5f);
        Invoke("jumpNextScene", 5);

        currentTime = Time.time;
        animationUpdate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        playAnimation();
    }

    void playSound()
    {
        vszed.Play();
    }

    void playAnimation()
    {
        var LogoColor = GetComponent<Image>().color;

        if (currentTime - animationUpdate >= 0.1f)
        {
            GetComponent<Image>().color = new Color(LogoColor.r, LogoColor.g, LogoColor.b, logoAlpha += 0.02f);
        }
    }

    void jumpNextScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
