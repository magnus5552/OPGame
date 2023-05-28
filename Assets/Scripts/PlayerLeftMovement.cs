using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Animator blackAnimator, whiteAnimator;
    [SerializeField]
    private Transform street;

    // Update is called once per frame
    void FixedUpdate()
    {
        var moveY = Input.GetAxis("Vertical");

        if (street.GetComponent<ChangeRun>().EventRun)
        {
            blackAnimator.SetBool("isMove", true);
            whiteAnimator.SetBool("isMove", true);
            transform.position += Vector3.left * velocity + new Vector3(0, moveY, 0);
        }
    }
}
