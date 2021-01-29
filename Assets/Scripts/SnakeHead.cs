using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead :  SnakeBody
{
    Vector2 movement;

    private SnakeBody tail = null;

    const float AddBodyPart = 0.1f;
    float AddTimer = AddBodyPart;

    public int partsToAdd = 0;
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

        if(partsToAdd > 0)
        {
            AddTimer -= Time.deltaTime;
            if(AddTimer <= 0)
            {
                AddTimer = AddBodyPart;
                addSnakeBody();
                partsToAdd--;
            }
        }
    }

    private void addSnakeBody()
    {
        if(tail == null)
        {
            //automatically awake when snake head eat cherry , and rest body awake automatically , and then it will become a tail of snake  
            SnakeBody spawn = Instantiate(GameController.instance.snakeBodyPrefab, transform.position,Quaternion.identity);
            //storing bodypart prefabs to "this" 
            spawn.isFollow = this;
            tail = spawn;
            spawn.turnIntoTail();
        }
        else
        {
            Vector3 newPosition = tail.transform.position;
            newPosition.z = newPosition.z + 0f;
            SnakeBody spawn = Instantiate(GameController.instance.snakeBodyPrefab, newPosition, Quaternion.identity);
            spawn.isFollow = null;
            spawn.turnIntoTail();
            tail.TurnIntoBody();
            tail = spawn;
        }
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

    public void ResetSnake()
    {
        tail = null;
        moveUp();
        partsToAdd = 10;
        AddTimer = AddBodyPart;
    }
}
