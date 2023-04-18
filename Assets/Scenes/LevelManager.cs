using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static int _currentLevel = 0;

    public void OnCollisionEnter2D(Collision2D col)
    {
        LoadNextScene();
    }

    public static void LoadNextScene()
    {
        _currentLevel += 1;
        SceneManager.LoadScene(_currentLevel);
    }
}
