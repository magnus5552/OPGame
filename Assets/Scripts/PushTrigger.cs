using UnityEngine;

public class PushTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator blackAnimator;
    [SerializeField]
    private Animator whiteAnimator;
    private static readonly int Collide = Animator.StringToHash("Collide");

    void Start()
    {
        GetComponent<PushOnCollide>().OnPush += ActivateTriggers;
    }

    private void ActivateTriggers(Collision2D col)
    {
        blackAnimator.SetTrigger(Collide);
        whiteAnimator.SetTrigger(Collide);
    }
}
