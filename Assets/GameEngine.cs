using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public static GameEngine instance;
    public AudioSource myAudioSource;
    public GameObject goddess;
    public GameObject note;
    public GameObject[] notes;
    bool canSpawn = false;
    public bool canMove = false;
    public float bpm;
    public float tempo;
    public bool gameStarted = false;
    void Awake()
    {
        instance = this;
        canSpawn = true;

        tempo = bpm / 60;

    }

    void Update()
    {
        print(tempo*Time.deltaTime);
        if (!gameStarted)
        {
            if(Input.anyKeyDown)
            {
                gameStarted = true;
                myAudioSource.Play();
            }
        }
        else
        {
            if(canSpawn)
            {
                GameObject notes = Instantiate(RandomNote(), goddess.transform.position+new Vector3( tempo *4f,0,0), Quaternion.identity);
                StartCoroutine(CanSpawn());
            }
            
        }
    }
    IEnumerator CanSpawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(tempo*Time.fixedDeltaTime*8);
        canSpawn = true;

    }

    public float NoteSpeed()
    {
        return tempo;
    }
    public GameObject RandomNote()
    {
        var i = Random.Range(0, 4);
        return notes[i];        
    }
     
    public void PlayerCantMove()
    {
        canMove = false;
    }
    public void PlayerCanMove()
    {
        canMove = true;
    }
   

}
