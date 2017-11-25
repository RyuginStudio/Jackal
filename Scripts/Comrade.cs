using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comrade : MonoBehaviour {
    public Sprite[] comradePics;
    public Sprite diePic; //死亡图片
    public bool isPromoteComrade; //可使武器升级的战友
    public AudioSource promoteEffect; //武器升级音效（只有可升级战友响应）
    public AudioSource[] comradeEffect; //战友上车语音（只有可升级战友响应）
    public AudioSource[] diedEffect; //战友死亡音效
    public AudioSource normalComradeEffect; //普通战友上车声音（只有可升级战友响应）
    private float swapStatusUpdate; //状态转换定时器
    private float invincibleUpdate; //无敌定时器(刚生成时无敌状态)
    private float currentTime;

    public enum status {
        idle,
        move
    }
    public status ComradeStatus;

    public enum direction {
        up,
        down,
        left,
        right
    }
    public direction ComradeDirec;

    void init () //初始化
    {
        invincibleOrNot ();
        //需要在具体预制体上操作(战友出生时状态)
        // ComradeStatus = status.move;
        // ComradeDirec = direction.down;
        animationPlay ();
    }

    // Use this for initialization
    void Start () {
        swapStatusUpdate = Time.time;
        currentTime = Time.time;
        invincibleUpdate = Time.time;

        init ();
    }

    // Update is called once per frame
    void Update () {
        currentTime = Time.time;

        invincibleOrNot ();
        changeStatus ();
        move ();
        blinkAnim ();
    }

    void OnTriggerEnter2D (Collider2D other) {
        //Debug.Log("contact with");
        switch (other.tag) //允许误伤
        {
            case "Player1":
                {
                    getInCar ();
                    break;
                }
            case "Explode":
                {
                    die ();
                    break;
                }
            case "BulletMachinGun":
                {
                    die ();
                    break;
                }
            case "BulletTankBunker":
                {
                    die ();
                    break;
                }
            case "bulletCharacMissile":
                {
                    die ();
                    break;
                }
            case "Grenade":
                {
                    die ();
                    break;
                }
            case "BulletSolider":
                {
                    die ();
                    break;
                }
            default:
                break;
        }
    }

    void OnCollisionEnter2D (Collision2D other) {
        switch (other.gameObject.tag) {
            case "Player1":
                {
                    getInCar ();
                    break;
                }
            case "EnemySolider":
                {
                    die ();
                    break;
                }
            case "TankBunker":
                {
                    die ();
                    break;
                }
        }
    }

    void changeStatus () //每隔两秒切换comrade状态
    {
        if (currentTime - swapStatusUpdate >= 2) {
            swapStatusUpdate = Time.time;

            switch (Random.Range (0, 2)) //随机状态
            {
                case 0:
                    {
                        ComradeStatus = status.idle;
                        break;
                    }
                case 1:
                    {
                        ComradeStatus = status.move;
                        break;
                    }
                default:
                    {
                        ComradeStatus = status.move;
                        break;
                    }

            }

            if (ComradeStatus == status.move) {
                switch (Random.Range (0, 4)) //随机方向
                {
                    case 0:
                        {
                            ComradeDirec = direction.up;
                            break;
                        }
                    case 1:
                        {
                            ComradeDirec = direction.down;
                            break;
                        }
                    case 2:
                        {
                            ComradeDirec = direction.left;
                            break;
                        }
                    case 3:
                        {
                            ComradeDirec = direction.right;
                            break;
                        }
                }

            }
            animationPlay ();
        }
    }

    void animationPlay () {
        if (ComradeStatus == status.idle) {
            foreach (var item in GetComponents<AnimationPlayer> ()) {
                item.autoPlay = false;

                if (item.Tag == "WaveHand") {
                    item.autoPlay = true;
                }
            }

        } else {
            string tag = ComradeDirec.ToString ();

            foreach (var item in GetComponents<AnimationPlayer> ()) {
                item.autoPlay = false;

                if (item.Tag == tag) {
                    item.autoPlay = true;
                }
            }

        }
    }

    void move () {
        if (ComradeStatus == status.move) {
            var step = GameData.comradeSpeed * Time.deltaTime;

            switch (ComradeDirec) {
                case direction.up:
                    {
                        transform.position = new Vector2 (transform.position.x, transform.position.y + step);
                        break;
                    }
                case direction.down:
                    {
                        transform.position = new Vector2 (transform.position.x, transform.position.y - step);
                        break;
                    }
                case direction.left:
                    {
                        transform.position = new Vector2 (transform.position.x - step, transform.position.y);
                        break;
                    }
                case direction.right:
                    {
                        transform.position = new Vector2 (transform.position.x + step, transform.position.y);
                        break;
                    }

            }
        }
    }

    public void die () {
        if (!invincibleOrNot ()) {
            GetComponent<SpriteRenderer> ().sprite = diePic;
            Destroy (GetComponent<Rigidbody2D> ());
            Destroy (GetComponent<Collider2D> ());
            Destroy (this);

            foreach (var item in GetComponents<AnimationPlayer> ())
                Destroy (item);

            diedEffect[Random.Range (0, 5)].Play ();
            Destroy (gameObject, 1.5f);
        }

    }

    public void getInCar () //上车
    {
        if (isPromoteComrade) {
            comradeEffect[Random.Range (0, 5)].Play ();
            promoteEffect.Play ();
            CharacterAttack.getInstance ().firePromote ();
        } else {
            normalComradeEffect.Play ();
        }

        Destroy (GetComponent<SpriteRenderer> ());
        Destroy (GetComponent<Rigidbody2D> ());
        Destroy (GetComponent<Collider2D> ());
        Destroy (this);

        foreach (var item in GetComponents<AnimationPlayer> ())
            Destroy (item);

        Destroy (gameObject, 1.5f);
    }

    void blinkAnim () //替换成不同颜色的对应帧
    {
        if (isPromoteComrade) {
            var spriteName = GetComponent<SpriteRenderer> ().sprite.name;

            int pic_idx = 0;
            int.TryParse (spriteName.Substring (8), out pic_idx); //截取“comrade”后的数字
            pic_idx += 10; //一行十张图

            if (pic_idx >= comradePics.Length) {
                pic_idx = pic_idx % 10;
            }

            GetComponent<SpriteRenderer> ().sprite = comradePics[pic_idx];
        }

    }

    bool invincibleOrNot () {
        if (currentTime - invincibleUpdate > GameData.comradeInvincibleTime) {
            GetComponent<Collider2D> ().isTrigger = false;
            return false;
        } else {
            GetComponent<Collider2D> ().isTrigger = true;
            return true;
        }
    }
}