using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField]
    private bool isMove;
    [SerializeField]
    private float offset;
    [SerializeField]
    private Transform street;

    // Start is called before the first frame update
    void Start()
    {
        offset = 0;
        isMove = false;
        CheckLayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            CheckLayer();
        }
    }

    private void CheckLayer()
    {
        var segments = street.GetComponent<Generation>().segments;
        var bottom = street.GetComponent<Generation>().bottomSideGeneration;
        var isIncluded = false;
        var y = (transform.position + new Vector3(0, offset, 0)).y;

        for (var i = 0; i < 20; i++)
        {
            if (y > bottom + (19 - i) * segments)
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10 + i;
                isIncluded = true;
                break;
            }
        }

        if (!isIncluded)
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 29;
    }
}
