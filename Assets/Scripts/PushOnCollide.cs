using System;
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
    private float _elapsedTime;
    private float _walkawayTime => WalkawayDistance / WalkawaySpeed;
    public bool IsPushed => _elapsedTime >= IgnoreTimeLimit;
    
    private float _startTime;
    private GameObject _collider;
    private Func<Vector3> _lerp;

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
            _collider.transform.position = _lerp();
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
        var distance = new Vector3(WalkawayDistance * directon, 0);
        var pos = col.gameObject.transform.position;
        _startTime = Time.time;
        _collider = col.gameObject;

        _lerp = () => Vector3.Lerp(pos, pos + distance, (Time.time - _startTime) / _walkawayTime);
    }

    public event Action<Collision2D> OnPush;
}
