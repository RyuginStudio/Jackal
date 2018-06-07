using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{

    private float currentTime;
    private float animationUpdate;
    private bool choiceBlink = false;  //闪烁动画
    public GameObject carChoicePic;
    public GameObject mask1P;
    public GameObject mask2P;
    public GameObject blinkMask;
    public GameObject ExplodeEffect;

    public Button btn_1_Player;
    public Button btn_2_Players;

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
        itemBlink(blinkMask);
    }

    void itemBlink(GameObject whichMask)  //1p、2p选好后闪烁
    {
        if (choiceBlink)
        {
            if (currentTime - animationUpdate > 0.2f && currentTime - animationUpdate < 0.3f)
            {
                whichMask.SetActive(true);
            }
            else if (currentTime - animationUpdate > 0.3f)
            {
                whichMask.SetActive(false);
                animationUpdate = Time.time;
            }
        }
    }

    void jumpScene(int Players)
    {
        StartCoroutine(SceneTransition.getInstance().loadScene("MissionViewScene", 1, 2));
    }

    public void onBtn1Player()
    {
        (ExplodeEffect.GetComponents<AudioSource>())[Random.Range(0, 5)].Play();
        carChoiceDisplay(btn_1_Player.transform);
        blinkMask = mask1P;
        choiceBlink = true;
        btn_1_Player.GetComponent<Button>().interactable = false;
        btn_2_Players.GetComponent<Button>().interactable = false;
        jumpScene(1);
    }

    public void onBtn2Players()
    {
        (ExplodeEffect.GetComponents<AudioSource>())[Random.Range(0, 5)].Play();
        carChoiceDisplay(btn_2_Players.transform);
        blinkMask = mask2P;
        choiceBlink = true;
        btn_1_Player.GetComponent<Button>().interactable = false;
        btn_2_Players.GetComponent<Button>().interactable = false;
        jumpScene(2);
    }

    public void carChoiceDisplay(Transform p)
    {
        var pos = carChoicePic.transform.position;
        carChoicePic.transform.position = new Vector3(pos.x, p.position.y, pos.z);
    }
}
