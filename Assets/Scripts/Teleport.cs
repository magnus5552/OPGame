using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] 
    public GameObject target;

    private Teleport _targetTeleport;

    private bool _isAbleToTeleport = true;

    public void Start()
    {
        _targetTeleport = target.GetComponent<Teleport>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isAbleToTeleport) return;
        
        other.transform.position = target.transform.position;
        _isAbleToTeleport = false;
        _targetTeleport._isAbleToTeleport = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isAbleToTeleport = true;
    }
}
