using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject specialSpellParticle;
    void Start()
    {
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
}
