using System.Collections.Generic;
using System.Linq;
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
            sprites[4].position += Vector3.left * offset1;
            sprites[5].position += Vector3.left * offset1;
            (sprites[0], sprites[1], sprites[2], sprites[3], sprites[4], sprites[5]) =
            (sprites[4], sprites[5], sprites[0], sprites[1], sprites[2], sprites[3]);
            
            for (var i = 0; i < sprites.Count; i++)
                sprites[i].GetComponent<SpriteRenderer>().sortingOrder = i / 2 + 1;
            
            
            street.GetComponent<Generation>().DeleteGeneration(sprites[0]);
            street.GetComponent<Generation>().Generate(sprites[0]);
        }
    }

    private void MoveSprites()
    {
        foreach (var sprite in sprites)
        {
            sprite.position += Vector3.right * scrollSpeed;
        }
    }
}