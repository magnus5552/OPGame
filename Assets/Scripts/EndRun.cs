using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRun : MonoBehaviour
{
    [SerializeField]
    private Transform street;
    [SerializeField]
    private Animator john;

    // Start is called before the first frame update

    public void EndChase()
    {
        street.GetComponent<ChangeRun>().EventRun = false;
        john.SetBool("isMove", false);
    }
}
