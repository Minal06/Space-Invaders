using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] float topBound = 30;
    [SerializeField] float lowerBound = -16;

    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            
            // deactivate 
            gameObject.SetActive(false);

        }
        else if (transform.position.z < lowerBound)
        {
            gameObject.SetActive(false);
        }

    }
}
