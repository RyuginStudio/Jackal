using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public AudioSource[] ExplodeEffect;

    // Use this for initialization
    void Start()
    {
        playExplodeEffect();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playExplodeEffect()
    {
        var randValue = Random.Range(0, 5);
        ExplodeEffect[randValue].Play();
    }
}
