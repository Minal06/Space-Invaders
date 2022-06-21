using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;    

    private void Start()
    {
        scoreText.text = "Score: " + PlayerScore.score;
        WhoWon();
    }


    void WhoWon()
    {        
        if (GameManager.isPlayerDead)
        {
            loseText.SetActive(true);
        }
        else
        {
            winText.SetActive(true);
        }
    }


    public void StartGame()
    {      
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
