using System;
using System.Linq;
using DefaultNamespace;
using System.Threading.Tasks;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] public Mode currentMode;
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private float delay = 2;
    private AudioSource _audio;
    private GameObject[] _whiteObjects;
    private GameObject[] _blackObjects;

    private bool _isAbleToChangeMode;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        currentMode = Mode.White;
        _whiteObjects = GameObject.FindGameObjectsWithTag("WhiteObject");
        _blackObjects = GameObject.FindGameObjectsWithTag("BlackObject");
        //AddEvents();
        UpdateMode();
        _isAbleToChangeMode = true;
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
        if (!Input.GetKeyUp(_keyCode) || !_isAbleToChangeMode) return;
        
        ChangeModeDelay();
        _audio.PlayOneShot(_audio.clip);
        ChangeMode();
    }

    public async void ChangeModeDelay()
    {
        _isAbleToChangeMode = false;
        await Task.Delay((int)delay * 1000);
        _isAbleToChangeMode = true;
    }

    public void ChangeMode()
    {
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