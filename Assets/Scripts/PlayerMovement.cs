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

    private bool _isPlayerMove;
    private static readonly int IsPlayerMove = Animator.StringToHash("IsPlayerMove");

    private Facing _facing;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void FlipIfDirectionChanged(float dir)
    {
        if ((dir >= 0 || _facing == Facing.Left) && (dir <= 0 || _facing == Facing.Right)) return;

        Flip();
    }

    private void Flip()
    {
        _facing = _facing == Facing.Left ? Facing.Right : Facing.Left;

        var scale = _cc.gameObject.transform.localScale;
        scale.x *= -1;
        _cc.gameObject.transform.localScale = scale;
    }

    private void Move()
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

        var (dx, dy) = (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _isPlayerMove = dx != 0 || dy != 0;
        ActivateTriggers();
        FlipIfDirectionChanged(dx);

        _cc.velocity = new Vector3(dx, dy) * velocity;
    }

    private void ActivateTriggers()
    {
        blackAnimator.SetBool(IsPlayerMove, _isPlayerMove);
        whiteAnimator.SetBool(IsPlayerMove, _isPlayerMove);
    }
}

enum Facing
{
    Right,
    Left
}

