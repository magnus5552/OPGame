using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class PushOnCollide : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float WalkawayDistance = 2;
    [SerializeField] 
    public float WalkawaySpeed = 2;
    
    [SerializeField] 
    public float IgnoreTimeLimit = 0.1f;
    private float _startTime;
    private float _elapsedTime;
    private float _walkawayTime => WalkawayDistance / WalkawaySpeed;
    public bool IsPushed => _elapsedTime >= IgnoreTimeLimit;
    
    private Action _move;

    private float _boxColliderMinY;
    private float _boxColliderMaxY;

    public void Start()
    {
        var bounds = GetComponent<BoxCollider2D>().bounds;
        _boxColliderMaxY = bounds.max.y;
        _boxColliderMinY = bounds.min.y;

        OnPush += SetMoveFunction;
    }

    private void Update()
    {
        if (Time.time - _startTime < _walkawayTime)
        {
            _move?.Invoke();
        }
    }

    private void OnCollisionEnter2D()
    {
        _elapsedTime = 0;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.bounds.max.y < _boxColliderMinY || col.collider.bounds.min.y > _boxColliderMaxY)
            return;
        
        if (!IsPushed)
        {
            _elapsedTime += Time.deltaTime;
            return;
        }

        OnPush?.Invoke(col);
    }

    private void SetMoveFunction(Collision2D col)
    {
        var directon = col.gameObject.transform.position.x < transform.position.x ? -1 : 1;
        var distance = new Vector3(WalkawaySpeed * WalkawayDistance * directon, 0);
        _startTime = Time.time;
        
        var rb = col.gameObject.GetComponent<Rigidbody2D>();

        _move = () => rb.AddForce(distance);
    }

    public event Action<Collision2D> OnPush;
}
