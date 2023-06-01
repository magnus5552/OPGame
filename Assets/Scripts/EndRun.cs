using System;
using UnityEngine;
using UnityEngine.Playables;

public class EndRun : MonoBehaviour
{
    [SerializeField]
    private Transform street;
    [SerializeField]
    private Animator john;

    [SerializeField] 
    private PlayableDirector _director;

    private ChangeRun _changeRun;

    private void Start()
    {
        _changeRun = street.GetComponent<ChangeRun>();
    }

    public void EndChase()
    {
        _changeRun.EventRun = false;
        john.SetBool("isMove", false);
        _director.Play();
    }
}
