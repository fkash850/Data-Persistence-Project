using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (MenuManager.Instance != null && !MenuManager.Instance.BestPlayer.Equals(""))
        {
            HighScoreText.text = $"Best Score: {MenuManager.Instance.BestPlayer} : {MenuManager.Instance.HighScore}";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit(); // Original code to quit Unity player
        }
    }
}