using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] 
    private MiniGame game;
    public void Start()
    {
        game.OnGameEnd += GetComponent<SignalReceiver>().GetReactionAtIndex(1).Invoke;
    }

    public void EndLevel()
    {
        SceneManager.LoadScene("Level4");
    }
}
