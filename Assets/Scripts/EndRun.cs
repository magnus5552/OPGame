using System;
using UnityEngine;

public class EndRun : MonoBehaviour
{
    [SerializeField]
    private Transform street;
    [SerializeField]
    private Animator john;

    private ChangeRun _changeRun;

    private void Start()
    {
        _changeRun = street.GetComponent<ChangeRun>();
    }

    public void EndChase()
    {
        
        _changeRun.EventRun = false;
        john.SetBool("isMove", false);
    }
}
