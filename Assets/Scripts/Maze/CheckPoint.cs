using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Transform checkPoints, counter1, counter2;
    [SerializeField]
    private Sprite blackSprite, whiteSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            counter1.GetComponent<WatchCounter>().countWatches -= 1;
            counter2.GetComponent<WatchCounter>().countWatches -= 1;
            checkPoints.GetComponent<LastCheckPoint>().AddCheckPoint(transform);
            if (transform.tag == "BlackObject")
                transform.GetComponent<SpriteRenderer>().sprite = blackSprite;
            else if (transform.tag == "WhiteObject")
                transform.GetComponent<SpriteRenderer>().sprite = whiteSprite;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
            
    }
}
