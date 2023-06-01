using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var playerPosition = player.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerPosition.x, playerPosition.y, -10), Time.deltaTime * 3);
    }
}
