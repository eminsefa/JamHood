﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public static GameEngine instance;
    public AudioSource myAudioSource;
    public GameObject goddess;
    public GameObject note;
    public GameObject[] notes;
    public bool canMove = false;
    public bool enemyCanMove = false;
    public float bpm;
    public float tempo;
    public float frameFix;
    public bool gameStarted = false;

    public int specialSpellCombo;
    public GameObject particlePrefab;

    public Camera cam;
    public GameObject player;

    public Transform[] spawnPos;

    void Awake()
    {
        instance = this;

        
        tempo = (60f / bpm);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("asd");
    }

    void Update()
    {
        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);
        if (!gameStarted)
        {
            if(Input.anyKeyDown)
            {
                gameStarted = true;
                myAudioSource.Play();
                InvokeRepeating("SpawnNote", 0f, tempo);
                FindObjectOfType<GhostBoss>().GetComponent<GhostBoss>().StartSummonning();
            }
        }
    }

    void SpawnNote()
    {
        GameObject notes = Instantiate(RandomNote(), spawnPos[Random.Range(0,spawnPos.Length)].position, Quaternion.identity); 
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
    public void EnemyCanMove()
    {
           enemyCanMove = true;
        Enemy[] scripts = FindObjectsOfType<Enemy>();
        GameObject[] enemies = new GameObject[scripts.Length];
        for (int i = 0; i< enemies.Length; i++)
        {
            enemies[i] = scripts[i].gameObject;

            enemies[i].GetComponent<Rigidbody2D>().velocity += EnemyMove();
        }
       
        EnemyCantMove();
    }
    
    public void EnemyCantMove()
    {
        enemyCanMove = false;
        
    }
    public Vector2 EnemyMove()
    {
        var i = Random.Range(0, 100);
        Vector2 randomMove = Vector2.zero;
        if (i < 25)
        {
            randomMove = new Vector2(0, 1);
        }
        else if (i < 50)
        {
            randomMove = new Vector2(1, 0);
        }
        else if (i < 75)
        {
            randomMove = new Vector2(0, -1);
        }
        else if (i < 100)
        {
            randomMove = new Vector2(-1, 1);
        }
        return randomMove;
    }
    public void ActivateNoteParticle(Color color)
    {
        particlePrefab.GetComponent<ParticleSystem>().startColor = color;
        GameObject particle = Instantiate(particlePrefab, goddess.transform.position, Quaternion.identity);
        Destroy(particle, 2f);
    }
}
