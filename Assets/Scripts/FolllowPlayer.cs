using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FolllowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float distance;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + new Vector3(-4, -1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveVector = new();
        var brotherPosition = transform.position;
        var playerPosition = player.position;
        var differenceX = playerPosition.x - brotherPosition.x;
        var differenceY = playerPosition.y - brotherPosition.y;
        var currentDistance = Math.Sqrt(differenceX * differenceX + differenceY * differenceY);

        if (currentDistance > Math.Abs(distance) * 3f)
            moveVector = new();
        else if (currentDistance > Math.Abs(distance) / 2f)
            moveVector = new Vector3(1 / 3f * differenceX, 1 / 4f * differenceY, 0);

        transform.position = Vector3.Lerp(brotherPosition, brotherPosition + moveVector,
            Time.deltaTime * Math.Abs((int)distance) / 2f);
    }
}
