using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoneMovement : MonoBehaviour
{
    [SerializeField]
    private float velocityX, velocityY, distance;
    [SerializeField]
    private Animator jone;
    [SerializeField]
    private Transform street, player, eventSystem;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var eventRun = street.GetComponent<ChangeRun>().EventRun;
        var bottomSide = street.GetComponent<Generation>().bottomSideGeneration;
        var topSide = street.GetComponent<Generation>().topSideGeneration;

        if (eventRun)
        {
            jone.SetBool("isMove", true);
            var offsetY = Random.Range(-velocityY, velocityY);
            if (transform.position.y >= (topSide - 3f) || transform.position.y <= (bottomSide + 3f))
                offsetY = -offsetY;

            transform.position += new Vector3(velocityX, offsetY, 0);
        }

        if ((player.position.x - transform.position.x) <= distance)
        {
            // ������ ��������
            eventSystem.GetComponent<EndRun>().EndChase();
        }
    }

    public void ChangeVelocity(float value)
    {
        velocityX += value;
    }


}
