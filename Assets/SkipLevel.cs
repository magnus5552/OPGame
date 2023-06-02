using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour
{
    [SerializeField] private KeyCode button = KeyCode.Return;

    void Update()
    {
        if (Input.GetKeyUp(button))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
