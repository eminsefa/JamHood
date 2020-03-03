using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeponKeeper : MonoBehaviour
{
    public static WeeponKeeper instance;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FindObjectOfType<Player>().transform.position + new Vector3(-8f, 4f,0);
        weapon.GetComponent<SpriteRenderer>().sprite = FindObjectOfType<Player>().weaponSprite;
    }
}
