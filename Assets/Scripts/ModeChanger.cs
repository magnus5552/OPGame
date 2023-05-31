using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] public Mode currentMode;
    [SerializeField] private KeyCode _keyCode;
    private AudioSource _audio;
    private GameObject[] _whiteObjects;
    private GameObject[] _blackObjects;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        currentMode = Mode.White;
        _whiteObjects = GameObject.FindGameObjectsWithTag("WhiteObject");
        _blackObjects = GameObject.FindGameObjectsWithTag("BlackObject");
        //AddEvents();
        UpdateMode();
    }

    private void AddEvents()
    {
        foreach (var obj in _whiteObjects.Concat(_blackObjects))
        {
            obj.AddComponent<InstanceGameChanger>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(_keyCode))
        {
            ChangeMode();
        }
    }

    public void ChangeMode()
    {
        _audio.PlayOneShot(_audio.clip);
        Debug.Log(_audio.isPlaying);
        currentMode = currentMode switch
        {
            Mode.White => Mode.Black,
            Mode.Black => Mode.White,
            _ => throw new ArgumentOutOfRangeException()
        };
        UpdateMode();
    }

    private void UpdateMode()
    {
        foreach (var obj in _whiteObjects)
        {
            obj.SetActive(currentMode == Mode.White);
        }

        foreach (var obj in _blackObjects)
        {
            obj.SetActive(currentMode == Mode.Black);
        }
    }
}

public enum Mode
{
    White,
    Black
}