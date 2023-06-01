using UnityEngine;
using System;

public class FolllowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float distance;

    private Animator _brother;

    private void Start()
    {
        _brother = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveVector = new();
        var brotherPosition = transform.position;
        var playerPosition = player.position - new Vector3(0, 1, 0);
        var differenceX = playerPosition.x - brotherPosition.x;
        var differenceY = playerPosition.y - brotherPosition.y;
        var currentDistance = Math.Sqrt(differenceX * differenceX + differenceY * differenceY);

        if (currentDistance > Math.Abs(distance) / 2f && currentDistance <= Math.Abs(distance) * 3f)
            moveVector = new Vector3(1 / 3f * differenceX, 1 / 4f * differenceY, 0);

        _brother.SetBool("BrotherRun", moveVector.magnitude > 0);

        transform.position = Vector3.Lerp(brotherPosition, brotherPosition + moveVector,
            Time.deltaTime * Math.Abs((int)distance) / 2f);
    }
}
