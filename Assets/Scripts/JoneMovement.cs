using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoneMovement : MonoBehaviour
{
    [SerializeField]
    private float velocityX, velocityY, bottomSide, topSide, distance;
    [SerializeField]
    private Animator jone;
    [SerializeField]
    private Transform street, player;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var eventRun = street.GetComponent<ChangeRun>().EventRun;

        if (eventRun)
        {
            jone.SetBool("isMove", true);
            var offsetY = Random.Range(-velocityY, velocityY);
            if (transform.position.y >= topSide || transform.position.y <= bottomSide)
                offsetY = -offsetY;

            transform.position += new Vector3(velocityX, offsetY, 0);
        }

        if ((player.position.x - transform.position.x) <= distance)
        {
            // Запуск катсцены
            street.GetComponent<ChangeRun>().EventRun = false;
        }
    }

    public void ChangeVelocity(float value)
    {
        velocityX += value;
    }


}
