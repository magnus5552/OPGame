using UnityEngine;

public class MarketStop : MonoBehaviour
{
    [SerializeField]
    private Transform street, player;

    public void StartRun()
    {
        street.gameObject.SetActive(true);
        player.GetComponent<Rigidbody2D>().velocity = new Vector3();
        street.GetComponent<ChangeRun>().EventRun = true;
        var movement = player.GetComponent<PlayerMovement>();
        if (movement.Facing == Facing.Right)
            movement.Flip();
            
        player.position = new Vector3(120, -10, 0);
    }
}
