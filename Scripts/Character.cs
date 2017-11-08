using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float currentTime;
    float directionUpdate;

    public Sprite sp_up;
    public Sprite sp_down;
    public Sprite sp_left;
    public Sprite sp_right;
    public Sprite sp_leftUp;
    public Sprite sp_leftDown;
    public Sprite sp_rightUp;
    public Sprite sp_rightDown;


    // Use this for initialization
    void Start()
    {
        currentTime = Time.time;
        directionUpdate = currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        CharacterMove();
    }

    public enum Status
    {
        idle,
        move,
    }
    public Status CharacterStatus;

    public enum Direction  //八方向
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

        transform.Translate(Vector3.right * horizontal * GameData.CharacterSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * GameData.CharacterSpeed * Time.deltaTime);

        if (currentTime - directionUpdate > GameData.TurnSensitivity)  //要先转到斜方向，不是立刻转到上、下、左、右
        {
            directionUpdate = currentTime;
            CharacDirectControl(horizontal, vertical);
            CharacDirectAnima();
        }

    }

    void CharacDirectControl(float x, float y)  //方向控制器(很奇葩的操控)
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

    void CharacDirectAnima()  //转向动画
    {
        switch (CharacterDirection)
        {
            case Direction.up:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_up;
                    break;
                }
            case Direction.down:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_down;
                    break;
                }
            case Direction.left:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_left;
                    break;
                }
            case Direction.right:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_right;
                    break;
                }
            case Direction.leftUp:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_leftUp;
                    break;
                }
            case Direction.leftDown:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_leftDown;
                    break;
                }
            case Direction.rightUp:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_rightUp;
                    break;
                }
            case Direction.rightDown:
                {
                    this.GetComponent<SpriteRenderer>().sprite = sp_rightDown;
                    break;
                }

        }


    }
}