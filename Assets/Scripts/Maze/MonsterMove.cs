using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private List<GameObject> points;
    private int nextPoint;
    private Vector3 nextPosition;
    private Rigidbody2D _cc;

    private void Start()
    {
        _cc = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var point = points[nextPoint];
        nextPosition = point.transform.position;
        _cc.velocity = (nextPosition - transform.position).normalized * velocity;
        if ((transform.position - nextPosition).magnitude < 1)
            nextPoint = (nextPoint + 1) % (points.Count);
            
    }
}
