using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCheckPoint : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPosition;
    private List<Vector3> whiteCheckPoints; 
    private List<Vector3> blackCheckPoints;

    private void Start()
    {
        whiteCheckPoints = new();
        whiteCheckPoints.Add(startPosition);
        blackCheckPoints = new();
        blackCheckPoints.Add(startPosition);
    }

    public void AddCheckPoint(Transform watch)
    {
        if (watch.tag == "WhiteObject")
            whiteCheckPoints.Add(watch.position);
        else if (watch.tag == "BlackObject")
            blackCheckPoints.Add(watch.position);
    }

    public Vector3 GoToBlackLastCheckPoint()
        => blackCheckPoints[blackCheckPoints.Count - 1];
    
    public Vector3 GoToWhiteLastCheckPoint()
        => whiteCheckPoints[whiteCheckPoints.Count - 1];
}
