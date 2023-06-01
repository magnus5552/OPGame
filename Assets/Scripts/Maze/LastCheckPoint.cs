using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCheckPoint : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPosition;
    private List<Vector3> checkPoints;

    private void Start()
    {
        checkPoints = new();
        checkPoints.Add(startPosition);
    }

    public void AddCheckPoint(Transform watch)
        => checkPoints.Add(watch.position);

    public Vector3 GoToLastCheckPoint()
        => checkPoints[checkPoints.Count - 1];
}
