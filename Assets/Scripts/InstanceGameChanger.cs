using UnityEngine;

namespace DefaultNamespace
{
    public class InstanceGameChanger : MonoBehaviour
    {
        private ModeChanger _gameChanger;
        private Mode? _mode;

        public void Start()
        {
            _gameChanger = FindObjectOfType<ModeChanger>();
            _mode = tag switch
            {
                "WhiteObject" => Mode.White,
                "BlackObject" => Mode.Black,
                _ => null
            };
        }

        public void OnEnable()
        {
            if (_mode != _gameChanger.currentMode) 
                gameObject.SetActive(false);
        }
    }
}