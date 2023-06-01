using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            ExitGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
