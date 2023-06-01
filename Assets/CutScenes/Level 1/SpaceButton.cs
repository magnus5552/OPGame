using UnityEngine;

public class SpaceButton : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(_keyCode))
        {
            gameObject.SetActive(false);
        }
    }
}
