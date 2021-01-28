using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    Vector2 deltaMovement;
    protected SnakeBody isFollow = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(deltaMovement.y > 0) { gameObject.transform.localEulerAngles = new Vector3(0, 0, 0); }
            else if(deltaMovement.y < 0) { gameObject.transform.localEulerAngles = new Vector3(0, 0, 180); }
                else if(deltaMovement.x < 0) { gameObject.transform.localEulerAngles = new Vector3(0, 0, 90); }
                    else if(deltaMovement.x > 0) { gameObject.transform.localEulerAngles = new Vector3(0, 0, -90); }
    }
}
