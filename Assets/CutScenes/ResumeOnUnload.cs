using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class ResumeOnUnload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var reciever = GetComponent<SignalReceiver>();
        SceneManager.sceneUnloaded += _ => reciever.GetReactionAtIndex(1).Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
