using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class JoneMovement : MonoBehaviour
{
    [SerializeField]
    private float velocityX, velocityY, distance;
    [SerializeField]
    private Animator jone;
    [SerializeField]
    private Transform street, player, eventSystem;

    private Generation _generation;
    private ChangeRun _changeRun;
    private EndRun _endRun;

    private void Start()
    {
        _generation = street.GetComponent<Generation>();
        _changeRun = street.GetComponent<ChangeRun>();
        _endRun = eventSystem.GetComponent<EndRun>();
    }

    void FixedUpdate()
    {
        var eventRun = _changeRun.EventRun;
        if (!eventRun) return;
        
        var bottomSide = _generation.bottomSideGeneration;
        var topSide = _generation.topSideGeneration;
        
        jone.SetBool("isMove", true);
        var offsetY = Random.Range(-velocityY, velocityY);
        if (transform.position.y >= topSide - 3f || transform.position.y <= bottomSide + 3f)
            offsetY = -offsetY;

        transform.position += new Vector3(velocityX, offsetY, 0);

        if (player.position.x - transform.position.x <= distance)
        {
            _endRun.EndChase();
        }
    }

    public void ChangeVelocity(float value)
    {
        velocityX += value;
    }
}
