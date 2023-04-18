using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] private Mode _currentMode;
    [SerializeField] private KeyCode _keyCode;
    private GameObject[] _whiteObjects;
    private GameObject[] _blackObjects;

    // Start is called before the first frame update
    void Start()
    {
        _currentMode = Mode.White;
        _whiteObjects = GameObject.FindGameObjectsWithTag("WhiteObject");
        _blackObjects = GameObject.FindGameObjectsWithTag("BlackObject");
        
        UpdateMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(_keyCode))
        {
            ChangeMode();
            UpdateMode();
        }
    }

    private void ChangeMode()
    {
        _currentMode = _currentMode switch
        {
            Mode.White => Mode.Black,
            Mode.Black => Mode.White,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void UpdateMode()
    {
        foreach (var obj in _whiteObjects)
        {
            obj.SetActive(_currentMode == Mode.White);
        }

        foreach (var obj in _blackObjects)
        {
            obj.SetActive(_currentMode == Mode.Black);
        }
    }
}

public enum Mode
{
    White,
    Black
}