using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    
    private Rigidbody2D _cc;
    
    [SerializeField]
    private Animator blackAnimator;
    [SerializeField]
    private Animator whiteAnimator;

    private bool _isPlayerMove;
    private static readonly int IsPlayerMove = Animator.StringToHash("IsPlayerMove");

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var (dx, dy) = (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        _isPlayerMove = dx != 0 || dy != 0;
        ActivateTriggers();

        _cc.velocity = new Vector3(dx, dy) * velocity;
    }
    
    private void ActivateTriggers()
    {
        blackAnimator.SetBool(IsPlayerMove, _isPlayerMove);
        whiteAnimator.SetBool(IsPlayerMove, _isPlayerMove);
    }
}

