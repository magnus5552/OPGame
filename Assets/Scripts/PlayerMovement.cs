using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Animator blackAnimator, whiteAnimator;

    private Rigidbody2D _cc;

    private bool _isPlayerMove;
    private static readonly int IsPlayerMove = Animator.StringToHash("IsPlayerMove");

    public Facing Facing;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        OnTransformChange();
    }

    private void FlipIfDirectionChanged(float dir)
    {
        if ((dir >= 0 || Facing == Facing.Left) && (dir <= 0 || Facing == Facing.Right)) return;

        Flip();
    }

    public void Flip()
    {
        Facing = Facing == Facing.Left ? Facing.Right : Facing.Left;

        var scale = _cc.gameObject.transform.localScale;
        scale.x *= -1;
        _cc.gameObject.transform.localScale = scale;
    }

    private void Move()
    {

        var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        _cc.velocity = movement * velocity;

        var (dx, dy) = (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _isPlayerMove = dx != 0 || dy != 0;
        ActivateTriggers();
        FlipIfDirectionChanged(dx);

        _cc.velocity = new Vector3(dx, dy) * velocity;
    }

    private void ActivateTriggers()
    {
        blackAnimator.SetBool(IsPlayerMove, _isPlayerMove);
        whiteAnimator.SetBool(IsPlayerMove, _isPlayerMove);
    }
    
    private void OnTransformChange()
    {
        SetAnimatorsBool(transform.hasChanged);

        transform.hasChanged = false;
    }

    public void SetAnimatorsBool(bool value)
    {
        blackAnimator.SetBool("BlackMove", value);
        whiteAnimator.SetBool("WhiteMove", value);
    }
}

public enum Facing
{
    Right,
    Left
}

