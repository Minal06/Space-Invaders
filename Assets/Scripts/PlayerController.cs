using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] float speed = 20.0f;
    [SerializeField] float xRange = 20;   


    // Update is called once per frame
    void Update()
    {
        // Check for left and right bounds
        Bounds();

        // Player movement left to right
        Movement();

        //shooting
        Shot();        
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledBullet("PlayerBullet");
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }
    }

    void Bounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
