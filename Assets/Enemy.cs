using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if(GameEngine.instance.enemyCanMove)
        {
            transform.position+=GameEngine.instance.EnemyMove();
            GameEngine.instance.EnemyCantMove();
        }
    }
}
