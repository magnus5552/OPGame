using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketStop : MonoBehaviour
{
    [SerializeField]
    private Transform street, player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector3();
        street.GetComponent<ChangeRun>().EventRun = true;
        player.position = new Vector3(120, -10, 0);
    }
}
