using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSee : MonoBehaviour
{
    [SerializeField]
    private float maxDistance, velocity;
    private List<Ray> rays;
    private string[] tags;
    private Vector3 direction;
    

    // Start is called before the first frame update
    void Start()
    {
        rays = new();
        for (var x = -1; x < 2; x++)
            for (var y = -1; y < 2; y++)
            {
                if (x * y != 0 || (x == 0 && y == 0))
                    continue;
                var ray = new Ray(transform.position, new Vector3(x, y, 0));
                rays.Add(ray);
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindEmptiness();
        MoveMonster();
    }

    private void MoveMonster()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + direction * velocity, Time.deltaTime * 2);
    }

    private void FindEmptiness()
    {
        tags = new string[]
        {
            "Empty",
            "Empty",
            "Empty",
            "Empty",
        };
        var foundPlayer = -1;
        var countWalls = 0;
        var directions = new Vector3[4];

        for (var i = 0; i < rays.Count; i++)
        {
            int layerMask = 1 << LayerMask.NameToLayer("Wall");
            var ray = rays[i];
            ray.origin = transform.position;
            var hit = Physics2D.Raycast(ray.origin, ray.direction, maxDistance, layerMask);
            if (hit)
            {
                var gameObject = hit.collider.gameObject;
                tags[i] = gameObject.tag;
                switch (gameObject.tag)
                {
                    case "Wall":
                        countWalls += 1;
                        break;
                    case "Monster":
                        break;
                    case "WhiteObject" or "BlackObject":
                        foundPlayer = i;
                        break;
                }
            }
            else
            {
                directions[i] = rays[i].direction;
            }    
        }
        if (directions[0] != new Vector3() || directions[3] != new Vector3())
        {
            direction = direction;
        }
        if (foundPlayer != -1)
            direction = rays[foundPlayer].direction;
        else if (countWalls == 3)
            direction = (-1) * direction;
        else if (countWalls == 2)
        {
            for (var i = 0; i < directions.Length; i++)
            {
                if (directions[i] == new Vector3())
                    continue;

                if (direction == directions[i])
                    break;

                if (directions[i] != (-1) * direction)
                    direction = directions[i];
            }
        }
        else if (countWalls == 1 || countWalls == 0)
        {
            FindDirection(directions);
        }
    }

    private void FindDirection(Vector3[] directions)
    {
        var indexes = new List<int>();

        for (var i = 0; i < directions.Length; i++)
        {
            if (directions[i] == (-1) * direction
                || directions[i] == new Vector3())
                continue;

            indexes.Add(i);
        }

        var randomIndex = UnityEngine.Random.Range(0, indexes.Count);
        direction = directions[indexes[randomIndex]];
    }
}
