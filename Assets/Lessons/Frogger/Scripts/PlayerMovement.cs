using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Direction direction = Direction.NONE;
    float speedPerSec = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set the movement direction
        if (Keyboard.current.wKey.isPressed)
        {
            direction = Direction.UP;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            direction = Direction.DOWN;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            direction = Direction.LEFT;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            direction = Direction.RIGHT;
        }
        else
        {
            direction = Direction.NONE;
        }

        //Move the player
        switch (direction)
        {
            case Direction.NONE: break;
            case Direction.UP:
                transform.position += new Vector3(0,speedPerSec * Time.deltaTime, 0);
                break;
            case Direction.DOWN:
                transform.position -= new Vector3(0, speedPerSec * Time.deltaTime, 0);
                break;
            case Direction.LEFT:
                transform.position -= new Vector3(speedPerSec * Time.deltaTime, 0, 0);
                break;
            case Direction.RIGHT:
                transform.position += new Vector3(speedPerSec * Time.deltaTime, 0, 0);
                break;
        }
    }
}

enum Direction
{
    NONE, UP, DOWN, LEFT, RIGHT
}
