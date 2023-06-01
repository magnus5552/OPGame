using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField] 
    public GameObject text;
    [SerializeField] 
    public GameObject bookOpened;

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

    private void OnMouseUp()
    {
        bookOpened.SetActive(true);
    }
}
