using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    //[SerializeField] int scoreValue;

    private void OnTriggerEnter(Collider other)
    {   
        switch (gameObject.tag)
        {
            case "PlayerBullet":
                switch (other.gameObject.tag)
                {
                    case "Base":
                        gameObject.SetActive(false);                                              
                break;
                    case "Enemy":
                        gameObject.SetActive(false);
                        Destroy(other.gameObject);
                        PlayerScore.score += Enemy.scoreValue;
                        break;

                    case "EnemyBullet":
                        gameObject.SetActive(false);
                        other.gameObject.SetActive(false);
                        break;

                    case null:
                        break;
                }
                break;


            case "EnemyBullet":
                switch (other.gameObject.tag)
                {
                    case "Base":
                        gameObject.SetActive(false);
                        break;
                    case "Player":
                        gameObject.SetActive(false);                        
                        
                        break;

                    //case "PlayerBullet":
                    //    gameObject.SetActive(false);
                    //    break;

                    case null:
                        break;
                }
                break;
            case null:
                Debug.LogWarning("NO TAG");
                break;
        }               

        //gameObject.SetActive(false);
        //Destroy(gameObject);       
    }

}
