using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private Transform jone;

    private void OnTriggerEnter(Collider other)
    {
        var rightSide = gameObject.GetComponent<EdgeCollider2D>().bounds.max.x;
        var leftSide = gameObject.GetComponent<EdgeCollider2D>().bounds.min.x;
        var otherLeftSide = other.bounds.min.x;
        var otherRigthSide = other.bounds.max.x;
        if (otherLeftSide >= leftSide || otherRigthSide <= rightSide)
            jone.GetComponent<JoneMovement>().ChangeVelocity(0.1f);
    }
}
