using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    Vector2 deltaMovement;
    //follow snake head or not 
    public SnakeBody isFollow = null;

    public bool isTail = false;

    private SpriteRenderer spriteRenderer = null;

    const int PARTSREMEMBER = 10;
    public Vector3[] previousPosition = new Vector3[PARTSREMEMBER];

    public int setIndex = 0;
    public int getIndex = -(PARTSREMEMBER - 1);

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    virtual public void Update()
    {
        if (!GameController.instance.alive) return;

        Vector3 followHead;
        if(isFollow != null)
        {
            if(isFollow.getIndex > -1)
            {
                followHead = isFollow.previousPosition[isFollow.getIndex];
            }
            else
            {
                followHead = isFollow.transform.position;
            }
        }
        else
        {
            followHead = gameObject.transform.position;
        }

        
        previousPosition[setIndex].x = gameObject.transform.position.x;
        previousPosition[setIndex].y = gameObject.transform.position.y;
        previousPosition[setIndex].z = gameObject.transform.position.z;

        setIndex++;

        if (setIndex >= PARTSREMEMBER) { setIndex = 0; }

        getIndex++;

        if (getIndex >= PARTSREMEMBER) { getIndex = 0; }
        
        //not head
        if(isFollow != null)
        {
            Vector3 newPosition;
            if (isFollow.getIndex > -1)
            {
                newPosition = followHead;
            }
            else
            {
                newPosition = isFollow.transform.position;
            }
            newPosition.z += 0.01f;
            setMovement(newPosition - gameObject.transform.position);
            updateDirection();
            updatePosition();
        }
    }
    
    public void setMovement(Vector2 movement)
    {
        deltaMovement = movement;
    }
    public void updatePosition()
    {
        //position on axis
        gameObject.transform.position += (Vector3)deltaMovement;
    }
    public void updateDirection()
    {
        //position on screen direction on 3-D plane x,y,z axis we will use luner angles to represent angles 
        if(deltaMovement.y > 0) 
        { gameObject.transform.localEulerAngles = new Vector3(0, 0, 0); }
            else if(deltaMovement.y < 0) 
        { gameObject.transform.localEulerAngles = new Vector3(0, 0, 180); }
                else if(deltaMovement.x < 0) 
        { gameObject.transform.localEulerAngles = new Vector3(0, 0, 90); }
                    else if(deltaMovement.x > 0)
        { gameObject.transform.localEulerAngles = new Vector3(0, 0, -90); }
    }

    //turn the body into tail
    public void turnIntoTail()
    {
        isTail = true;
        spriteRenderer.sprite = GameController.instance.tailSprite;

    }
    public void TurnIntoBody()
    {
        isTail = false;
        spriteRenderer.sprite = GameController.instance.bodySprite;
    }
}
