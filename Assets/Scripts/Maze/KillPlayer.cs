using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform checkPoints, mainCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (transform.tag == "BlackObject")
            {
                other.transform.position = checkPoints.GetComponent<LastCheckPoint>().GoToBlackLastCheckPoint();
                mainCamera.position = new Vector3(other.transform.position.x, other.transform.position.y, -10);
            }
            else if (transform.tag == "WhiteObject")
            {
                other.transform.position = checkPoints.GetComponent<LastCheckPoint>().GoToWhiteLastCheckPoint();
                mainCamera.position = new Vector3(other.transform.position.x, other.transform.position.y, -10);
            }
        }
    }
}
