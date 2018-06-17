using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float currentTime;
    float directionUpdate;
    float moveAnimaUpdate;
    float invinTimeUpdate;  //无敌时间定时器
    public bool characInvincible;  //角色无敌状态
    public int PassengerHole;  //当前载客量  TODO：未启用
    public GameObject prefabExplode;

    // Use this for initialization
    void Start()
    {
        currentTime = Time.time;
        directionUpdate = Time.time;
        moveAnimaUpdate = Time.time;
        invinTimeUpdate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        CharacterMove();
        invincibleOrNot();  //判断无敌状态
    }

    public enum Status
    {
        idle,
        move,
    }
    public Status CharacterStatus;

    public enum Direction //八方向
    {
        up,
        down,
        left,
        right,
        leftUp,
        rightUp,
        leftDown,
        rightDown
    }
    public Direction CharacterDirection;

    void CharacterMove()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        //操纵角色刚体线速度
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * GameData.CharacterSpeed, vertical * GameData.CharacterSpeed);

        if (currentTime - directionUpdate > GameData.TurnSensitivity) //要先转到斜方向，不是立刻转到上、下、左、右
        {
            directionUpdate = currentTime;
            CharacDirectControl(horizontal, vertical);
            CharacDirectAnima();
        }

        if (CharacterStatus == Status.move && currentTime - moveAnimaUpdate > 0.05f)
        {
            moveAnimaUpdate = Time.time;
            CharacMoveAnim();
        }

    }

    void CharacMoveAnim() //移动动画
    {
        GameData.UpOrDown *= -1;
        var pos = this.transform.position;

        if (CharacterDirection == Direction.up || CharacterDirection == Direction.down) //上下要明显
        {
            this.transform.position = new Vector3(pos.x, pos.y += GameData.UpOrDown * 0.055f, pos.z);
            return;
        }

        this.transform.position = new Vector3(pos.x, pos.y += GameData.UpOrDown * 0.05f, pos.z);
    }

    void CharacDirectControl(float x, float y) //方向控制器(很奇葩的操控)
    {
        if (x == 1 && y == 0)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.down:
                    {
                        CharacterDirection = Direction.rightDown;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.right;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.right;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.right;
                        break;
                    }
            }
        }
        else if (x == -1 && y == 0)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.down:
                    {
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
            }
        }

        if (y == 1 && x == 0)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.down:
                    {
                        ;
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.right;
                        break;
                    }
            }
        }
        else if (y == -1 && x == 0)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.down:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.rightDown;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.right;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
            }
        }

        if (x == 1 && y == 1)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.down:
                    {
                        CharacterDirection = Direction.rightDown;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.right;
                        break;
                    }
            }
        }
        else if (x == 1 && y == -1)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.down:
                    {
                        CharacterDirection = Direction.rightDown;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.rightDown;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.right;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.rightDown;
                        break;
                    }
            }
        }

        if (x == -1 && y == 1)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.down:
                    {
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.rightUp;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
            }
        }
        else if (x == -1 && y == -1)
        {
            CharacterStatus = Status.move;

            switch (CharacterDirection)
            {
                case Direction.up:
                    {
                        CharacterDirection = Direction.leftUp;
                        break;
                    }
                case Direction.down:
                    {
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.left:
                    {
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.right:
                    {
                        CharacterDirection = Direction.rightDown;
                        break;
                    }
                case Direction.leftUp:
                    {
                        CharacterDirection = Direction.left;
                        break;
                    }
                case Direction.leftDown:
                    {
                        CharacterDirection = Direction.leftDown;
                        break;
                    }
                case Direction.rightUp:
                    {
                        CharacterDirection = Direction.up;
                        break;
                    }
                case Direction.rightDown:
                    {
                        CharacterDirection = Direction.down;
                        break;
                    }
            }
        }

        if (x == 0 && y == 0)
        {
            CharacterStatus = Status.idle;
        }
    }

    void CharacDirectAnima() //转向动画
    {
        switch (CharacterDirection)
        {
            case Direction.up:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                }
            case Direction.down:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                }
            case Direction.left:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                }
            case Direction.right:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                }
            case Direction.leftUp:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 45);
                    break;
                }
            case Direction.leftDown:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, 135);
                    break;
                }
            case Direction.rightUp:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, -45);
                    break;
                }
            case Direction.rightDown:
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, -135);
                    break;
                }

        }

    }

    void OnTriggerEnter2D(Collider2D other) //碰撞检测
    {
        switch (other.tag)
        {
            case "BulletTankBunker":
                {
                    CharacDiedBomb();
                    break;
                }

            case "BulletSolider":
                {
                    CharacDiedBomb();
                    break;
                }

        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        switch (collisionInfo.gameObject.tag)
        {
            case "TankBunker":
                {
                    CharacDiedBomb();
                    break;
                }
        }
    }

    void CharacDiedBomb()
    {
        if (!characInvincible)
        {
            var trans_BulletsAndExplode = GameObject.FindWithTag("trans_BulletsAndExplode").transform;
            GameObject.Destroy(gameObject); //销毁Jackal
            Instantiate(prefabExplode, transform.position, Quaternion.Euler(Vector3.zero), trans_BulletsAndExplode);
            GameControler.getInstance().characSpawn(transform.position);
        }
    }

    public void invincibleOrNot()  //是否无敌 => true为无敌
    {
        if (currentTime - invinTimeUpdate <= GameData.CharacterInvincibleTime)
        {
            characInvincible = true;

            //无敌闪烁
            foreach (var item in GetComponents<AnimationPlayer>())
            {
                if (item.Tag == "CommonInvincibleAnima")
                {
                    item.autoPlay = true;
                }
            }
        }
        else
        {
            characInvincible = false;
            foreach (var item in GetComponents<AnimationPlayer>())
            {
                if (item.Tag == "CommonInvincibleAnima")
                {
                    item.autoPlay = false;
                    GetComponent<SpriteRenderer>().sprite = item.AnimationFrames[0];
                }
            }
        }

    }

}