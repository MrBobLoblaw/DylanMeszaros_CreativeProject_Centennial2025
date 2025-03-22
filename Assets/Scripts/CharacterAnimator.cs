using UnityEngine;

public enum CharacterState
{
    Idle,
    Walking,
}

public class CharacterAnimator : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;
    public GameObject body;

    private Animation anim;
    private bool triggerCharacterAnim;

    private CharacterState currentState;

    void Start()
    {
        animator = GetComponent<Animator>();

        currentState = CharacterState.Idle;

        //anim = null;
        //heldObject = null;
    }

    void Update()
    {
        switch (currentState)
        {
            case CharacterState.Idle:
                animator.SetBool("Walking", false);
                break;
            case CharacterState.Walking:
                animator.SetBool("Walking", true);
                break;
            default:
                animator.SetBool("Walking", false);
                break;
        }
    }

    public void SetCharacterState(CharacterState state)
    {
        currentState = state;
    }
    public void TriggerAnim()
    {
        triggerCharacterAnim = true;
    }
}
