using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private Transform camera, player, brother;
    [SerializeField]
    private float rightOffset, leftOffset;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > 160)
        {
            var offsetVector = Vector3.left * leftOffset;
            player.position += offsetVector;
            camera.position += offsetVector;
            brother.position += offsetVector;
        }

        if (player.position.x < -120)
        {
            var offsetVector = Vector3.right * rightOffset;
            player.position += offsetVector;
            camera.position += offsetVector;
            brother.position += offsetVector;
        }
    }
}
