using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField]
	private int countItems = 3;

	public Stack<GameObject> sprites;

	public bool AddItem(GameObject sprite)
	{
		if(sprites.Count < countItems)
        {
			sprites.Push(sprite);
			return true;
		}

		return false;
	}

	public GameObject PopItem()
    {
		if (sprites.Count != 0)
        {
			var sprite = sprites.Pop();
			return sprite;
		}
			
		return null;
    }
}
