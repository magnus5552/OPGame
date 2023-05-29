using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int _currentLevel = 1;

    public void OnCollisionEnter2D(Collision2D col)
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        _currentLevel += 1;
        SceneManager.LoadScene($"Level{_currentLevel}");
    }
}
