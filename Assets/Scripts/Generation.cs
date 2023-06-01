using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField]
    private Transform john;
    [SerializeField]
    private List<string> nameList;
    [SerializeField]
    private List<GameObject> gameObjectsList;
    public float LeftSideGeneration, RightSideGeneration, bottomSideGeneration, topSideGeneration;
    public float segments => (topSideGeneration - bottomSideGeneration) / 10;
   
    private List<(float, float, GameObject, string)> field;


    public void Generate(Transform sprite)
    {
        field = new();
        LeftSideGeneration = sprite.position.x - 56.6f * 2;
        RightSideGeneration = sprite.position.x + 56.6f * 2;
        var generationLength = (RightSideGeneration - LeftSideGeneration) / 10;   

        for (var i = 0; i < 10; i++)
        {
            var y = Random.Range(bottomSideGeneration, topSideGeneration);
            var x = Random.Range(LeftSideGeneration + i * generationLength, LeftSideGeneration + (i + 1) * generationLength);
            var index = Random.Range(0, gameObjectsList.Count - 1);
            var item = Instantiate(gameObjectsList[index]);
            var barrierComponent = item.GetComponent<Barrier>();
            barrierComponent.jone = john;
            barrierComponent.street = transform;

            field.Add((x, y, item, nameList[index]));
        }

        foreach (var item in field)
        {
            item.Item3.transform.position = new Vector3(item.Item1, item.Item2, 0);
            item.Item3.transform.SetParent(sprite);
            switch (item.Item4)
            {
                case "BluCar":
                    transform.GetComponent<Layer>().CheckLayer(item.Item3.transform, -1.45f);
                    item.Item3.transform.localScale *= 5;
                    break;
                case "GreenCar":
                    transform.GetComponent<Layer>().CheckLayer(item.Item3.transform, -1.55f);
                    item.Item3.transform.localScale *= 5;
                    break;
                case "RedCar":
                    transform.GetComponent<Layer>().CheckLayer(item.Item3.transform, -1.45f);
                    item.Item3.transform.localScale *= 5;
                    break;
                case "ClosedRoad":
                    item.Item3.GetComponent<SpriteRenderer>().sortingOrder = 10;
                    item.Item3.transform.localScale *= 3;
                    break;
            }
        }
    }

    public void DeleteGeneration(Transform parent)
    {
        while (parent.childCount > 0)
        {
            DestroyImmediate(parent.GetChild(0).gameObject);
        }
    }
}
