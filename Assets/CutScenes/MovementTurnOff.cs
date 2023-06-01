using UnityEngine;

public class MovementTurnOff : MonoBehaviour
{
    [SerializeField]
    private Transform street;

    private ChangeRun _changeRun;

    private PlayerMovement _movement;
    // Start is called before the first frame update
    void Start()
    {
        _changeRun = street.GetComponent<ChangeRun>();
        _movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.enabled = !_changeRun.EventRun;
    }
}
