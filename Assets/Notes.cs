using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public KeyCode keyToPress;
    bool keyDestored = false;
    public bool canBePressed = false;
    public GameObject goddess;
    float speed;
    Rigidbody2D rb;
    void Awake()
    {
        speed = GameEngine.instance.NoteSpeed();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (GameEngine.instance.gameStarted)
        {
            rb.position = Vector2.MoveTowards(transform.position, goddess.transform.position, speed*Time.deltaTime);
        }


        if (canBePressed)
        {
            if(Input.GetKeyDown(keyToPress))
            {
                Destroy(gameObject);
                keyDestored = true;
                GameEngine.instance.PlayerCanMove();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Goddess")
        {
            canBePressed = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Goddess")
        {
            StartCoroutine(NoteMissed());
        }
    }
    IEnumerator NoteMissed()
    {
        yield return new WaitForSeconds(0.3f);
        if(!keyDestored)
        {
            GameEngine.instance.PlayerCantMove();
            Destroy(gameObject);
        }
    }
}
