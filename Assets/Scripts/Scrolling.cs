using System;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField]
    private Transform street;
    [SerializeField]
    private float scrollSpeed, side, offset1;
    [SerializeField]
    private List<Transform> sprites;

    private void Start()
    {
        street.GetComponent<Generation>().Generate(sprites[2]);
        street.GetComponent<Generation>().Generate(sprites[0]);
    }

    void FixedUpdate()
    {
        if (street.GetComponent<ChangeRun>().EventRun)
            MoveSprites();

        if (sprites[3].position.x >= side || sprites[2].position.x >= side)
        {
            sprites[4].GetComponent<SpriteRenderer>().sortingOrder = 1;
            sprites[5].GetComponent<SpriteRenderer>().sortingOrder = 1;
            sprites[2].GetComponent<SpriteRenderer>().sortingOrder = 3;
            sprites[3].GetComponent<SpriteRenderer>().sortingOrder = 3;
            sprites[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
            sprites[1].GetComponent<SpriteRenderer>().sortingOrder = 2;
            sprites[4].position += Vector3.left * offset1;
            sprites[5].position += Vector3.left * offset1;
            (sprites[0], sprites[1], sprites[2], sprites[3], sprites[4], sprites[5]) =
            (sprites[4], sprites[5], sprites[0], sprites[1], sprites[2], sprites[3]);
            street.GetComponent<Generation>().DeleteGeneration(sprites[0]);
            street.GetComponent<Generation>().Generate(sprites[0]);
        }
    }

    private void MoveSprites()
    {
        sprites[0].position += Vector3.right * scrollSpeed;
        sprites[1].position += Vector3.right * scrollSpeed;
        sprites[2].position += Vector3.right * scrollSpeed;
        sprites[3].position += Vector3.right * scrollSpeed;
        sprites[4].position += Vector3.right * scrollSpeed;
        sprites[5].position += Vector3.right * scrollSpeed;
    }
}