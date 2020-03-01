using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBoss : MonoBehaviour
{
    public Transform[] shrines;
    public GameObject[] enemies;
    public bool attackMode = false;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (attackMode)
        {
            GhostBossMove();
            GetComponent<Animator>().SetTrigger("attackMode");
        }
        else
        {
            StartCoroutine(SummonEnemies());
        }

    }
    IEnumerator SummonEnemies()
    {
            yield return new WaitForSeconds(2f);
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], shrines[Random.Range(0, shrines.Length)].position, Quaternion.identity);           
            StartCoroutine(SummonEnemies());
            yield return new WaitForSeconds(30f);
            attackMode = true;
            GhostBossMove();
        
    }
    public void StartSummonning()
    {
        StartCoroutine(SummonEnemies());
    }
    void GhostBossMove()
    {
        if(!GameEngine.instance.enemyCanMove)
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.transform.position, 1f);
        GameEngine.instance.EnemyCantMove();
    }
}
