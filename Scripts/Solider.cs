using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : Enemy
{
    private float currentTime;
    private float attackUpdate;
    private float swapStatusUpdate;
    private Vector3 attackPos;
    public GameObject prefabBulletSolider;
    public AudioSource[] diedEffect;
    public AudioSource[] shootEffect;
    public Sprite diePic;
    public Sprite lookLeft;
    public Sprite lookRight;
    public Sprite lookUp;
    public Sprite lookDown;


    // Use this for initialization
    void Start()
    {
        currentTime = Time.time;
        swapStatusUpdate = currentTime - 2;

        this.target = GameObject.FindGameObjectWithTag("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        changeStatus();
        move();
        attack();
    }

    public enum status
    {
        attack,
        move
    }
    public status SoliderStatus;

    public enum direction
    {
        up,
        down,
        left,
        right
    }
    public direction SoliderDirec;

    public override void move()
    {

        if (SoliderStatus == status.move && GameObject.FindGameObjectsWithTag("Player1") != null)
        {
            var step = GameData.soliderSpeed * Time.deltaTime;
            target = GameObject.FindGameObjectWithTag("Player1");

            if (target != null)
            {
                //运动
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);

                //方向 => 限制“角度”
                if (transform.position.x > target.transform.position.x && transform.position.x - target.transform.position.x > 1.5f)
                {
                    SoliderDirec = direction.left;
                }
                else if (transform.position.x < target.transform.position.x && transform.position.x - target.transform.position.x < -1.5f)
                {
                    SoliderDirec = direction.right;
                }
                else if (transform.position.y > target.transform.position.y)
                {
                    SoliderDirec = direction.down;
                }
                else
                {
                    SoliderDirec = direction.up;
                }

            }
            else //随机运动
            {
                switch (SoliderDirec)
                {
                    case direction.up:
                        {
                            transform.position = new Vector2(transform.position.x, transform.position.y + step);
                            break;
                        }
                    case direction.down:
                        {
                            transform.position = new Vector2(transform.position.x, transform.position.y - step);
                            break;
                        }
                    case direction.left:
                        {
                            transform.position = new Vector2(transform.position.x - step, transform.position.y);
                            break;
                        }
                    case direction.right:
                        {
                            transform.position = new Vector2(transform.position.x + step, transform.position.y);
                            break;
                        }

                }
            }

            animationPlay();
        }
    }

    void attack()
    {
        if (SoliderStatus == status.attack && currentTime - attackUpdate >= GameData.soliderAttackRate && GameObject.FindGameObjectWithTag("Player1") != null)
        {
            attackUpdate = Time.time;

            target = GameObject.FindGameObjectWithTag("Player1");

            //方向 => 限制“角度”
            if (transform.position.x > target.transform.position.x && transform.position.x - target.transform.position.x > 1.5f)
            {
                SoliderDirec = direction.left;
            }
            else if (transform.position.x < target.transform.position.x && transform.position.x - target.transform.position.x < -1.5f)
            {
                SoliderDirec = direction.right;
            }
            else if (transform.position.y > target.transform.position.y)
            {
                SoliderDirec = direction.down;
            }
            else
            {
                SoliderDirec = direction.up;
            }

            animationPlay();

            attackPos = target.transform.position;
            shootEffect[Random.Range(0, shootEffect.Length)].Play();
            var bulletPrefab = Instantiate(prefabBulletSolider, transform.position, Quaternion.Euler(Vector3.zero));
            bulletPrefab.GetComponent<Bullet>().Shotter = transform.gameObject; //通过脚本获取物体			
            bulletPrefab.GetComponent<Bullet>().attackPos = this.attackPos;
        }
    }

    void changeStatus() //每隔两秒切换Solider状态
    {
        if (currentTime - swapStatusUpdate >= 2)
        {
            swapStatusUpdate = Time.time;

            switch (Random.Range(0, 2)) //随机状态
            {
                case 0:
                    {
                        SoliderStatus = status.attack;
                        break;
                    }
                case 1:
                    {
                        SoliderStatus = status.move;
                        break;
                    }

            }

            if (GameObject.FindGameObjectWithTag("Player1") == null)
            {
                switch (Random.Range(0, 4)) //随机方向
                {
                    case 0:
                        {
                            SoliderDirec = direction.up;
                            break;
                        }
                    case 1:
                        {
                            SoliderDirec = direction.down;
                            break;
                        }
                    case 2:
                        {
                            SoliderDirec = direction.left;
                            break;
                        }
                    case 3:
                        {
                            SoliderDirec = direction.right;
                            break;
                        }
                }

            }

            animationPlay();
        }
    }

    void animationPlay()
    {
        if (SoliderStatus == status.attack)
        {
            foreach (var item in GetComponents<AnimationPlayer>())
            {
                item.autoPlay = false;

                switch (SoliderDirec)
                {
                    case direction.up:
                        {
                            GetComponent<SpriteRenderer>().sprite = lookUp;
                            break;
                        }
                    case direction.down:
                        {
                            GetComponent<SpriteRenderer>().sprite = lookDown;
                            break;
                        }
                    case direction.left:
                        {
                            GetComponent<SpriteRenderer>().sprite = lookLeft;
                            break;
                        }
                    case direction.right:
                        {
                            GetComponent<SpriteRenderer>().sprite = lookRight;
                            break;
                        }
                }
            }

        }
        else
        {
            string tag = SoliderDirec.ToString();

            foreach (var item in GetComponents<AnimationPlayer>())
            {
                item.autoPlay = false;

                if (item.Tag == tag)
                {
                    item.autoPlay = true;
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player1":
                {
                    die();
                    break;
                }
            case "Explode":
                {
                    die();
                    break;
                }
            case "BulletMachinGun":
                {
                    die();
                    break;
                }
            case "BulletCharacMissile":
                {
                    die();
                    break;
                }
            case "Grenade":
                {
                    die();
                    break;
                }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        switch (collisionInfo.gameObject.tag)
        {
            case "Player1":
                {
                    die();
                    break;
                }
        }
    }

    public void die()
    {
        GetComponent<SpriteRenderer>().sprite = diePic;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Collider2D>());
        Destroy(this);

        foreach (var item in GetComponents<AnimationPlayer>())
            Destroy(item);

        diedEffect[Random.Range(0, 5)].Play();
        Destroy(gameObject, 1.5f);
    }

}