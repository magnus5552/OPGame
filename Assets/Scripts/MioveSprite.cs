using UnityEngine;

public class MioveSprite : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Transform street;

    // Start is called before the first frame update
    // Update is called once per frame
    void FixedUpdate()
    {
        if (street.GetComponent<ChangeRun>().EventRun)
            transform.position = Vector3.Lerp(transform.position, Vector3.right * velocity, Time.deltaTime);
    }
}
