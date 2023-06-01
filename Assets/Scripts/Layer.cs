using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField]
    private List<Transform> moveRunObjects;
    private float[] offsets;

    // Start is called before the first frame update
    void Start()
    {
        offsets = new float[]
        {
            -3f,
            -3.5f,
            -3.5f
        };
        for (var i = 0; i < moveRunObjects.Count; i++)
            CheckLayer(moveRunObjects[i], offsets[i]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var eventRun = gameObject.GetComponent<ChangeRun>().EventRun;

        if (eventRun)
        {
            for (var i = 0; i < moveRunObjects.Count; i++)
                CheckLayer(moveRunObjects[i], offsets[i]);
        }
    }

    public void CheckLayer(Transform gameObject, float offset)
    {
        var segments = transform.GetComponent<Generation>().segments;
        var bottom = transform.GetComponent<Generation>().bottomSideGeneration;
        var isIncluded = false;

        var y = gameObject.transform.position.y + offset;

        for (var i = 0; i < 10; i++)
        {
            if (y > bottom + (9 - i) * segments)
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10 + i;
                isIncluded = true;
                break;
            }
        }

        if (!isIncluded)
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 20;
    }
}
