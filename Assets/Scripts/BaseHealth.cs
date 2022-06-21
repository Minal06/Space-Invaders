using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{

    [SerializeField] int health;
    private int bHealth;

    private void Awake()
    {
        health = bHealth;
    }

    // Update is called once per frame
    void Update()
    {
        BaseDestroy();
    }

    void BaseDestroy()
    {
        if (bHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        bHealth -= 1;
        Debug.Log(gameObject.name + bHealth);
        return;
    }
}
