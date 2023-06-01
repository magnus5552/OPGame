using UnityEngine;

public class OnHover : MonoBehaviour
{
    [SerializeField] 
    public GameObject text;

    public void Start()
    {
        text.SetActive(false);
    }

    public void OnMouseEnter()
    {
        text.SetActive(true);
    }

    public void OnMouseExit()
    {
        text.SetActive(false);
    }
}
