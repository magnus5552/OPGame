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

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var (dx, dy) = (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _cc.velocity = new Vector3(dx, dy) * velocity;
    }
}

