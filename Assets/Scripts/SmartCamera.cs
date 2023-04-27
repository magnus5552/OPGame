using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SmartCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float insideRightLeftSide;
    [SerializeField]
    private float insideUpDownSide;

    private bool isInsideRectangleX;
    private bool isInsideRectangleY;
    private float outsideRightLeftSide;
    private float outsideUpDownSide;

    private float maxSpeedPlayer;

    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
        (outsideRightLeftSide, outsideUpDownSide) = (6, 4);  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckAndMove();
    }

    //camera follows player, if it's necessery
    void CheckAndMove()
    {
        (var x, var y) = (0f, 0f);
        insideRightLeftSide =
            (outsideRightLeftSide - 0.5f < insideRightLeftSide)
            ? outsideRightLeftSide - 0.5f
            : insideRightLeftSide;
        insideUpDownSide =
            (outsideUpDownSide - 0.33f < insideUpDownSide)
            ? outsideUpDownSide - 0.33f
            : insideUpDownSide;

        insideRightLeftSide =
            (1 > insideRightLeftSide)
            ? 1f
            : insideRightLeftSide;
        insideUpDownSide =
            (0.66f > insideUpDownSide)
            ? 0.66f
            : insideUpDownSide;

        var cameraPosition = transform.position;
        var playerPosition = player.position;
        var differenceX = playerPosition.x - cameraPosition.x;
        var differenceY = playerPosition.y - cameraPosition.y;
        
        if (Math.Abs(differenceX) > outsideRightLeftSide)
            x = (1f / 2f) * differenceX;
        else if (Math.Abs(differenceX) > (int)(outsideRightLeftSide + insideRightLeftSide) / 2f)
        {
            x = (1f / 3f) * differenceX;
            isInsideRectangleX = true;
        }  
        else if (Math.Abs(differenceX) < 1f)
            isInsideRectangleX = false;
        else if (Math.Abs(differenceX) > insideRightLeftSide || isInsideRectangleX)
            x = ((differenceX < 0) ? -3f : 3f);

        if (Math.Abs(differenceY) > outsideUpDownSide) 
            y = (1f / 2f) * differenceY;
        else if (Math.Abs(differenceY) > (int)(outsideUpDownSide + insideUpDownSide) / 2f)
        {
            y = (1f / 3f) * differenceY;
            isInsideRectangleY = true;
        }
        else if (Math.Abs(differenceY) < 1f)
            isInsideRectangleY = false;
        else if (Math.Abs(differenceY) > insideUpDownSide || isInsideRectangleY)
            y = ((differenceY < 0) ? -3f : 3f);

        transform.position = Vector3.Lerp(transform.position, cameraPosition + new Vector3(x, y), 
            Time.deltaTime * (int)(outsideUpDownSide + insideUpDownSide) / 2f);
    }
}
