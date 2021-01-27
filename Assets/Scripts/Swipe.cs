using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    Vector2 start;
    Vector2 end;
    public static event System.Action<swipeDirection> onSwipe = delegate { };
    public enum swipeDirection
    {
        up,down,left,right
    };
    // Update is called once per frame
    void Update()
    {
        //for each input multiple touches on screen 
        foreach (Touch touch in Input.touches)
        {                              
            if (touch.phase == TouchPhase.Began)
            {
                start = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                end = touch.position;
                swipe();
            }
        }
        //mouse
        if(Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            end = Input.mousePosition;swipe();
        }
    }
    void swipe()
    {
        float distance = Vector2.Distance(start, end);
        if(distance > 5)
        {
            if (isSwipe())
            {
                if (end.y > start.y)
                {
                    onSwipe(swipeDirection.up);
                }
                else
                {
                    onSwipe(swipeDirection.down);
                }
            }
            else
            {
                if(end.x > end.y)
                {
                    onSwipe(swipeDirection.right);
                }
                else
                {
                    onSwipe(swipeDirection.left);
                }
            }
        }
    }
    bool isSwipe()
    {
        float vertical = Mathf.Abs(end.y - start.y);
        float horizonatal = Mathf.Abs(end.x - start.x);
        if (vertical > horizonatal)
            return true;
        return false;
    }
}
