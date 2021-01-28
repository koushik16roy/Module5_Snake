using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead :  SnakeBody
{
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        Swipe.onSwipe += SwipeDetection;
    }

    // Update is called once per frame
    void Update()
    {
        //calling from SnakeBody.cs for movement along the head 
        setMovement(movement);
        updateDirection();
        updatePosition();
    }
    //to detect swipe for snake calling swipe.cs 
    void SwipeDetection(Swipe.swipeDirection direction)
    {
        //checking the swipe direction
        switch (direction) 
        {
            case Swipe.swipeDirection.up:
                moveUp();
                break;
            case Swipe.swipeDirection.down:
                moveDown();
                break;
            case Swipe.swipeDirection.left:
                moveLeft();
                break;
            case Swipe.swipeDirection.right:
                moveRight();
                break;
        }
    }
    
    //all functions for snake movement with a constant speed using gamecontroller.cs 
    void moveUp()
    {
        movement = Vector2.up * GameController.instance.snakeSpeed * Time.deltaTime;
    }
    void moveDown()
    {
        movement = Vector2.down * GameController.instance.snakeSpeed * Time.deltaTime;
    }
    void moveLeft()
    {
        movement = Vector2.left * GameController.instance.snakeSpeed * Time.deltaTime;
    }
    void moveRight()
    {
        movement = Vector2.right * GameController.instance.snakeSpeed * Time.deltaTime;
    }
}
