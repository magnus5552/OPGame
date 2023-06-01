using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string[] levels = new string[] { "Level1", "Maze", "MiniGame" , "Level4" };
    private int _currentLevel = 0;

    public void OnCollisionEnter2D(Collision2D col)
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        _currentLevel += 1;
        SceneManager.LoadScene($"{levels[_currentLevel]}");
    }
}
