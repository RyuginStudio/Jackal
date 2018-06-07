using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public AudioSource vszed;

    // Use this for initialization
    void Start()
    {
        vszed.PlayDelayed(.5f);
        jumpNextScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void jumpNextScene()
    {
        StartCoroutine(SceneTransition.getInstance().loadScene("TitleScene", 5, 3));
    }
}
