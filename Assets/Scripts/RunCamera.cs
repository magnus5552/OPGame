using UnityEngine;

public class RunCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player, street;
    [SerializeField]
    private float offserFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        offserFromPlayer = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (street.GetComponent<ChangeRun>().EventRun)
        {
            transform.position = player.position + new Vector3(-offserFromPlayer, 0, -10);
            transform.GetComponent<Camera>().orthographicSize = 30;
        }
        else
        {
            transform.GetComponent<Camera>().orthographicSize = 15;
        }
            
    }
}
