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
        if ((otherLeftSide >= leftSide || otherRigthSide <= rightSide)
            && (jone.position - other.transform.position).x < Screen.width / 2)
            jone.position += Vector3.left * force; 
    }
}
