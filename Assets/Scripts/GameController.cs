using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    const float width = 5f;
    const float height = 2f;
    public float snakeSpeed = 1f;

    public SnakeBody snakeBodyPrefab = null;
    public GameObject rockPrefab = null;
    public GameObject eggPrefab = null;
    public GameObject goldEggPrefab = null;

    public Sprite tailSprite = null;
    public Sprite bodySprite = null;

    public SnakeHead snakeHead = null;

    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        instance=this;
        CreateWalls();
        StartGame();
        createEgg();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
       snakeHead.ResetSnake();
    }

    public void GameOver()
    {
        alive = false;
    }

    void CreateWalls()
    {
        
        //left - notdone
        Vector3 start = new Vector3(-width, -height, 0);
        Vector3 end = new Vector3(-width, +height, 0);
        CreateWall(start,end);
        //right - notdone
         start = new Vector3(width, -height, 0);
         end = new Vector3(width, +height, 0);
        CreateWall(start, end);
        //up - not done
        start = new Vector3(width, -height,  0  );
        end = new Vector3(-width, height, 0);
        CreateWall(start, end);
        //down - not done
        start = new Vector3(width, height, 0);
        end = new Vector3(width, -height, 0);
        CreateWall(start, end);
    }
    void CreateWall(Vector3 start,Vector3 end)
    {
        //calculation vector to create the rock form start to end
        float distance = Vector3.Distance(start, end);
        int noRocks = (int)(distance * 4);
        Vector3 delta = (start - end)/noRocks;

        //looping 
        Vector3 position = start;
        for(int rocks = 0; rocks < noRocks; rocks++)
        {
            float rotation = Random.Range(0, 360f);
            float scale = Random.Range(1.5f, 3f);
            CreateRock(position, scale, rotation);
            position += delta;
        }
    }
    void CreateRock(Vector3 position,float scale,float rotation)
    {
        GameObject rock = Instantiate(rockPrefab, position, Quaternion.Euler(0,0,rotation));
        rock.transform.localScale = new Vector3(scale, scale, 2);
    }

    //create egg at different position 
    void createEgg(bool golden = false)
    {
        Vector3 position; 
        position.x = -width + Random.Range(1f, (width * 2) - 2f);
        position.y = -width + Random.Range(1f, (height * 2) - 2f);
        position.z = 0;
        if(golden)
            Instantiate(goldEggPrefab, position, Quaternion.identity);
        else
            Instantiate(eggPrefab, position, Quaternion.identity);
    }
}
