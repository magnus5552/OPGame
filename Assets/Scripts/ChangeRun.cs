using UnityEngine;

public class ChangeRun : MonoBehaviour
{
    public bool EventRun;

    // Update is called once per frame
    public void ChangeEventRun()
        => EventRun = !EventRun;
}
