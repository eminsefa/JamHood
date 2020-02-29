using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float duration;
    float elapsedTime = 1;
    void Start()
    {
        duration= GameEngine.instance.tempo/4; 
        transform.position = new Vector2(2.5f , 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += 1 * Time.deltaTime;


        if (GameEngine.instance.canMove && elapsedTime>duration)
        {
            Move();

        }
        
    }
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0, 0);
            elapsedTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -1f, 0);
            elapsedTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0, 0);
            elapsedTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1f, 0);
            elapsedTime = 0;
        }
    }
}
