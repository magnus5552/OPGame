using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftMovement : MonoBehaviour
{
    [SerializeField]
    private Animator blackAnimator, whiteAnimator;
    [SerializeField]
    private Transform blackPlayer, whitePlayer;
    [SerializeField]
    private Transform street;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (street.GetComponent<ChangeRun>().EventRun)
        {
            blackAnimator.SetBool("BlackMove", true);
            whiteAnimator.SetBool("WhiteMove", true);
            transform.position += new Vector3(0, Input.GetAxis("Vertical")/10, 0);
        }
    }
}
