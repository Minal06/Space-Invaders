using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Enemy Spawn Setup")]
    [SerializeField] Transform holder;
    [SerializeField] Transform enemyPref;
    [SerializeField] Transform topLeftEnemy;

    [Header("Enemy Spawn Options")]
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] float space;

    [Header("Enemy Speed and Reach")]
    [SerializeField] float eSpeed;
    [SerializeField] float eRange;
    [SerializeField] float eDrop;
    [SerializeField] float lastEnemySpeed;
    private Vector3 eDirection = Vector2.right;

    private float gameOverLine = 14;

    private void Awake()
    {
        for ( int row = 0; row < rows; row++)
        {     
            for (int col = 0; col< columns; col++)
            {
                Vector3 startingPos = new Vector3(topLeftEnemy.position.x + col *space, topLeftEnemy.position.y, topLeftEnemy.position.z - row * space);
                Transform _enemy = Instantiate(enemyPref, startingPos, Quaternion.identity);
                _enemy.SetParent(holder);
            } 
        }
    }

    private void Update()
    {
        EnemyMove();
        FasterEnemy();
    }

    void EnemyMove()
    {
        transform.position += eDirection * eSpeed * Time.deltaTime;

        foreach (Transform enemy in holder)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (enemy.position.x <= -eRange || enemy.position.x >= eRange)
            {
                eSpeed = -eSpeed;

                Vector3 position = transform.position;
                position.z -= eDrop;
                transform.position = position;                

                return;
            }

            if (enemy.position.z <= -gameOverLine)
            {
                GameManager.isPlayerDead = true;
                GameManager.GameOver();
            }

        }

        
    }

    void FasterEnemy()
    {
        if(holder.childCount == 1)
        {
            eSpeed = lastEnemySpeed;
        }
    }

    void GameWin()
    {
        if(holder.childCount == 0)
        {
            GameManager.GameOver();
        }
    }
}
