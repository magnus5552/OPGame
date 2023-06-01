using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformExtensions : MonoBehaviour
{
    public void Reset()
    {
        var newPos = new Vector3(0, 0, transform.position.z);
        transform.position = newPos;
    }
}
