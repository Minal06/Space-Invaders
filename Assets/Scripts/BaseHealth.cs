using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public static int b_health = 2;

    // Update is called once per frame
    void Update()
    {
        BaseDestroy();
    }

    void BaseDestroy()
    {
        if (b_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
