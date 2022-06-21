using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPlayerDead = false;

    private void Awake()
    {
        Instance = this;    
    }




    public void GameOver()
    {

    }
}
