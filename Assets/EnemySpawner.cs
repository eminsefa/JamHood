using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    void Start()
    {
        foreach(Transform spawn in spawnPoints)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawn.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
