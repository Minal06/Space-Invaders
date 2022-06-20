using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {   
        switch (other.gameObject.tag)
        {
            case "Base":
                gameObject.SetActive(false);
                Destroy(other.gameObject);
                break;

            case "EnemyBullet":
                gameObject.SetActive(false);  
                other.gameObject.SetActive(false);                
                break;

            case null:
                break;
        }

        //gameObject.SetActive(false);
        //Destroy(gameObject);       
    }

}
