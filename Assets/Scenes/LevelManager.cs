using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Scene _currentScene;
    void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    public void LoadScene(int levelIndex)
    {
        SceneManager.LoadScene($"Level{levelIndex}");
    }
    
    public void LoadSceneAdditive(int levelIndex)
    {
        SceneManager.LoadScene($"Level{levelIndex}", LoadSceneMode.Additive);
        
        var scene = SceneManager.GetSceneByName($"Level{levelIndex}");
        SceneManager.SetActiveScene(scene);
    }

    public void UnloadScene(int levelIndex)
    {
        SceneManager.UnloadSceneAsync($"Level{levelIndex}");
    }
}
