using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int scoreValue {get; private set;}
    [SerializeField] int enemyPoints;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = enemyPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
