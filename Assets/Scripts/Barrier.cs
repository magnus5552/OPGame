using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private float force;

    public Transform jone, street;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var rightSide = gameObject.GetComponent<BoxCollider2D>().bounds.max.x;
        var leftSide = gameObject.GetComponent<BoxCollider2D>().bounds.min.x;
        var otherLeftSide = other.bounds.min.x;
        var otherRigthSide = other.bounds.max.x;
        if (otherLeftSide >= leftSide || otherRigthSide <= rightSide)
            jone.position = Vector3.Lerp(jone.position, Vector3.left * force, Time.deltaTime / 4);
    }
}
