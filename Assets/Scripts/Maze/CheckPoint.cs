using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Transform checkPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            checkPoints.GetComponent<LastCheckPoint>().AddCheckPoint(transform);
    }
}
