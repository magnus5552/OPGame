using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WatchCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject skull1, skull2, pink1, pink2, text, LockSprite, watchSprite;
    public int countWatches;

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
            skull1.SetActive(false);
            skull2.SetActive(false);
            pink1.SetActive(false);
            pink2.SetActive(false);
            LockSprite.SetActive(false);
            watchSprite.SetActive(false);
            gameObject.SetActive(false);
        }
        var textMesh = text.GetComponent<TextMeshProUGUI>();
        textMesh.text = $"{countWatches}";
    }
}
