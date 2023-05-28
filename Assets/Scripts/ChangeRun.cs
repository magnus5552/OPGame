using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRun : MonoBehaviour
{
    public bool EventRun;

    private void Start()
    {
        EventRun = false;
    }

    // Update is called once per frame
    public void ChangeEventRun()
        => EventRun = !EventRun;
}
