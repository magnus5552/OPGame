using UnityEngine;

public class PlayerLeftMovement : MonoBehaviour
{
    [SerializeField]
    private Transform street;

    private ChangeRun _changeRun;

    private void Start()
    {
        _changeRun = street.GetComponent<ChangeRun>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_changeRun.EventRun)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical")/10, 0);
        }
    }
}
