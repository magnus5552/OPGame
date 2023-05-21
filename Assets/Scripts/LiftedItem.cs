using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LiftedItem : MonoBehaviour
{
    [SerializeField]
    private float leftRightSide, upDownSide;
    [SerializeField]
    private GameObject player, thisObject;

    private bool isUsed;

    void Start()
    {
        isUsed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var playerPosition = player.transform.position;
        var objectPosition = transform.position;

        if (Math.Abs(playerPosition.x - objectPosition.x) < leftRightSide && Math.Abs(playerPosition.y - objectPosition.y) < upDownSide && Input.GetKey(KeyCode.E) && !isUsed)
        {
            var inventory = player.GetComponent<Inventory>();
            inventory.AddItem(thisObject);
            isUsed = true;
            thisObject.SetActive(false);
        }
        /*if (Math.Abs(playerPosition.x - objectPosition.x) < leftRightSide && Math.Abs(playerPosition.y - objectPosition.y) < upDownSide)
            Destroy(thisObject);*/
    }
}