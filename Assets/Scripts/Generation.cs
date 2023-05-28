using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gameObjects;
    private List<GameObject> items;
    private List<List<(float, float, GameObject)>> generationList;
    public float LeftSideGeneration, RightSideGeneration, bottomSideGeneration, topSideGeneration;
    public float segments => (topSideGeneration - bottomSideGeneration) / 20;
    
    private List<(float, float, GameObject)> field;
    // Start is called before the first frame update
    void Start()
    {
        bottomSideGeneration = -11.7f;
        topSideGeneration = -6.9f;
        items = new List<GameObject>();
        for (var i = 0; i < gameObjects.Count; i++)
        {
            for (var j = 0; j < 8; j++)
                items.Add(gameObjects[i]);
        }
    }

    private List<(float, float, GameObject)> Generate()
    {
        field = new();
        var generationLength = (RightSideGeneration - LeftSideGeneration) / 8;

        for (var i = 0; i < 8; i++)
        {
            var y = Random.Range(bottomSideGeneration, topSideGeneration);
            var x = Random.Range(LeftSideGeneration + i * generationLength, LeftSideGeneration + (i + 1) * generationLength);
            var index = Random.Range(0, items.Count - 1);
            var item = Instantiate(items[index]);
            field.Add((x, y, item));
        }

        return field;
    }

    public void OutputGeneration()
    {
        var fieldItems = Generate();
        foreach (var item in fieldItems)
            item.Item3.transform.position = new Vector3(item.Item1, item.Item2, 0);
    }
}
