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
    private AudioSource _audio;
    private bool _isFirstEventFrame;

    private float _johnHeight;

    private void Start()
    {
        _generation = street.GetComponent<Generation>();
        _changeRun = street.GetComponent<ChangeRun>();
        _endRun = eventSystem.GetComponent<EndRun>();
        _audio = GetComponent<AudioSource>();
        _isFirstEventFrame = true;
        _johnHeight = GetComponent<SpriteRenderer>().size.y;
    }

    void FixedUpdate()
    {
        var eventRun = _changeRun.EventRun;
        if (!eventRun) return;

        if (_isFirstEventFrame)
        {
            _audio.Play();
            _isFirstEventFrame = false;
        }
        
        var bottomSide = _generation.bottomSideGeneration;
        var topSide = _generation.topSideGeneration;
        
        jone.SetBool("isMove", true);
        var offsetY = Random.Range(-velocityY, velocityY);
        if (transform.position.y + _johnHeight + offsetY >= topSide || 
            transform.position.y + _johnHeight + offsetY <= bottomSide)
            offsetY = 0;

        transform.position += new Vector3(velocityX, offsetY, 0);

        if (player.position.x - transform.position.x <= distance)
        {
            _endRun.EndChase();
            _audio.Stop();
        }
    }

    public void ChangeVelocity(float value)
    {
        velocityX += value;
    }
}
