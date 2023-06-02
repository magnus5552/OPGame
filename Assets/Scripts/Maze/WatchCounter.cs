using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WatchCounter : MonoBehaviour
{
    [SerializeField]
    private Transform skull1, skull2, pink1, pink2, otherCounter;
    public int countWatches;
    [SerializeField]
    private GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        countWatches = 6;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countWatches == 0)
        {
            Destroy(skull1);
            Destroy(skull2);
            Destroy(pink1);
            Destroy(pink2);
            Destroy(otherCounter);
            Destroy(gameObject);
        }
        var textMesh = text.GetComponent<TextMeshProUGUI>();
        textMesh.text = $"{countWatches}";
    }
}
