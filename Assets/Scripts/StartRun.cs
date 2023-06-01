using UnityEngine;

public class StartRun : MonoBehaviour
{
    [SerializeField]
    private Transform street, player, jhon;

    public void StartChase()
    {
        player.GetComponent<SpriteRenderer>().flipX = true;
        player.position = new Vector3(120, -10, 0);
        street.GetComponent<ChangeRun>().EventRun = true;
    }
}
