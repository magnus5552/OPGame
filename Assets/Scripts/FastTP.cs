using UnityEngine;

public class FastTP : MonoBehaviour
{
    [SerializeField]
    public GameObject target;
    [SerializeField]
    private Transform fastCamera, brother;
    private FastTP _targetTeleport;

    private bool _isAbleToTeleport = true;

    public void Start()
    {
        _targetTeleport = target.GetComponent<FastTP>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isAbleToTeleport) return;

        var side = (other.transform.position.x - fastCamera.position.x >= 0) ? 0.5f : -0.5f;
        var differenceC = other.transform.position - fastCamera.position;
        //var differenceB = other.transform.position - brother.position;
        var differenceY = target.transform.position.y - other.transform.position.y;

        other.transform.position = target.transform.position - new Vector3(side, differenceY, 0);
        fastCamera.position = target.transform.position - differenceC - new Vector3(side, differenceY, 0);
        brother.position = target.transform.position; //- new Vector3(side, differenceY, 0) - differenceB

        _isAbleToTeleport = false;
        _targetTeleport._isAbleToTeleport = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isAbleToTeleport = true;
    }
}
