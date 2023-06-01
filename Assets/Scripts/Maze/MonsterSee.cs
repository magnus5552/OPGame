using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSee : MonoBehaviour
{
    [SerializeField]
    private float maxDistance, velocity;
    private Vector3[] directions;
    private Ray ray;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        directions = new Vector3[]
        {
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(-1, 0, 0),
            new Vector3(0, -1, 0)
        };
        ray = new Ray(transform.position, directions[0]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindEmptiness();
        MoveMonster();
    }

    private void MoveMonster()
    {
        
    }

    private void FindEmptiness()
    {
        ray.origin = transform.position;
        var cross = Physics.Raycast(ray.origin, ray.direction, maxDistance);

        if (!cross)
            transform.position = Vector3.Lerp(transform.position, transform.position + ray.direction * velocity, Time.deltaTime * 2);
        else
        {
            ray.direction = directions[index];
            index = (index + 1) % 4;
        }
            
            
    }
}
