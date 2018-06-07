using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionViewScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SceneTransition.getInstance().loadScene("MainScene", 3, 2));
    }

    // Update is called once per frame
    void Update()
    {

    }

}
