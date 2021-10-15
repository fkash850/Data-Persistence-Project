using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerInput;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (MenuManager.Instance != null && !MenuManager.Instance.BestPlayer.Equals(""))
        {
            highScoreText.gameObject.SetActive(true);
            highScoreText.text = $"Best Score: {MenuManager.Instance.BestPlayer} : {MenuManager.Instance.HighScore}";
            playerInput.text = MenuManager.Instance.CurrentPlayer;
        }
    }

    // Load main scene on start button click
    public void StartMain()
    {
        MenuManager.Instance.SavePlayer(playerInput.text);
        SceneManager.LoadScene(1);
    }

    // Exit application on exit button click
    public void Exit()
    {
        MenuManager.Instance.SavePlayer(playerInput.text);

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