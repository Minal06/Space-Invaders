using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public static int score;

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }


}
