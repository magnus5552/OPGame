using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Animator blackAnimator, whiteAnimator;

    private Rigidbody2D _cc;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (movement.magnitude > 0)
        {
            blackAnimator.SetBool("BlackMove", true);
            whiteAnimator.SetBool("WhiteMove", true);
        }
        else
        {
            blackAnimator.SetBool("BlackMove", false);
            whiteAnimator.SetBool("WhiteMove", false);
        }

        _cc.velocity = movement * velocity;
    }
}

