using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    private float _prevTimeScale;
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        if (Time.timeScale > 0)
        {
            _prevTimeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = _prevTimeScale;
            AudioListener.pause = false;
            pauseMenu.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
