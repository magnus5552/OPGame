using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoneMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity, maxDistance;
    [SerializeField]
    private Animator jone;
    [SerializeField]
    private Transform street;
    private bool isFar = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (street.GetComponent<ChangeRun>().EventRun && isFar)
        {
            jone.SetBool("isMove", true);
            transform.position += Vector3.left * velocity * 2;
        }
        else if (street.GetComponent<ChangeRun>().EventRun)  
        {
            jone.SetBool("isMove", true);
            transform.position += Vector3.left * velocity;
        }
    }

    public void ChangeVelocity(float value)
    {
        velocity += value;
        if (velocity >= maxDistance)
            isFar = true;
        //else if(velocity )
    }


}
