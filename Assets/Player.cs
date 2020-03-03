using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject specialSpellParticle;
    public GameObject weapon;
    public string anim;
    public Sprite weaponSprite;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = null;
    }

    void Update()
    {
        if (GameEngine.instance.canMove)
        {
            if (GameEngine.instance.specialSpellCombo >= 5)
            {
                SpecialAttack();
                
            }
            else
            {
                Move();
            }
        }

    }
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, LayerMask.GetMask("Enemy"));
            if (hit.collider != null)
            {
                weapon.transform.position = hit.collider.transform.position;
                weapon.GetComponent<Weapon>().PlayAnimation();
                Destroy(hit.collider.gameObject);
            }
            else
            {
                transform.position += new Vector3(1f, 0, 0);
                GameEngine.instance.PlayerCantMove();
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Enemy"));
            if (hit.collider != null)
            {
                weapon.transform.position = hit.collider.transform.position;
                weapon.GetComponent<Weapon>().PlayAnimation();
                Destroy(hit.collider.gameObject);
            }
            else
            {
                transform.position += new Vector3(0, -1f, 0);
                GameEngine.instance.PlayerCantMove();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 1f, LayerMask.GetMask("Enemy"));
            if (hit.collider != null)
            {
                weapon.transform.position = hit.collider.transform.position;
                weapon.GetComponent<Weapon>().PlayAnimation();
                Destroy(hit.collider.gameObject);
                
            }
            else
            {
                transform.position += new Vector3(-1f, 0, 0);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                GameEngine.instance.PlayerCantMove();
            }                   
        
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, LayerMask.GetMask("Enemy"));
            if (hit.collider != null)
            {
                weapon.transform.position = hit.collider.transform.position;
                weapon.GetComponent<Weapon>().PlayAnimation();
                Destroy(hit.collider.gameObject);
            }
            else
            {
                transform.position += new Vector3(0, 1f, 0);
                GameEngine.instance.PlayerCantMove();
            }
            
        }
    }
    void SpecialAttack()
    {
        GameEngine.instance.specialSpellCombo = 0;
        GameObject particle = Instantiate(specialSpellParticle, transform.position, Quaternion.identity);
        Destroy(particle, 2f);
        foreach (Collider2D collider in Physics2D.OverlapBoxAll(transform.position, 2 * Vector2.one, 0f, LayerMask.GetMask("Enemy")))
        {
            Destroy(collider.gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Sword")
        {
            weaponSprite = collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            Destroy(collider.gameObject);
            anim = "Sword";
        }
        if (collider.gameObject.tag == "Rapier")
        {
            weaponSprite = collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            Destroy(collider.gameObject);
            anim = "Rapier";
        }
        if (collider.gameObject.tag == "Axe")
        {
            weaponSprite = collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            Destroy(collider.gameObject);
            anim = "Axe";
        }
        if (collider.gameObject.tag == "Dagger")
        {
            weaponSprite = collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            Destroy(collider.gameObject);
            anim = "Dagger";
        }
        

        if (collider.tag=="LevelChanger")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        
        
    }
}
