using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool isPlayerDead = false;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        PlayerScore.score = 0;
        isPlayerDead = false;
    }



    public void GameOver()
    {        
        SceneManager.LoadScene(2);

        Debug.Log(isPlayerDead);
    }

    public void PlayerIsDead()
    {
        isPlayerDead = true;
    }
}
