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
    public GameObject particle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = GameEngine.instance.NoteSpeed();

        if (transform.position.x > 0)
        {
             rb.velocity = new Vector2(-speed * 5, 0);
        }
        else if (transform.position.x<0)
        {
             rb.velocity = new Vector2(speed * 5, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Update()
    {   


        if (canBePressed)
        {
            if(Input.GetKeyDown(keyToPress))
            {
                GameEngine.instance.PlayerCanMove();                
                keyDestored = true;
                GameEngine.instance.ActivateNoteParticle(GetComponent<SpriteRenderer>().color);
                Destroy(gameObject);
                GameEngine.instance.specialSpellCombo++;
            }
        }
    }
    
        
    
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag=="Goddess")
        {
            canBePressed = true;
            GameEngine.instance.EnemyCanMove();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="Goddess")
        {
            if(!keyDestored)
            {
                GameEngine.instance.PlayerCantMove();
                Destroy(gameObject);
                GameEngine.instance.specialSpellCombo = 0;
                
            }
        }
    }   
}
