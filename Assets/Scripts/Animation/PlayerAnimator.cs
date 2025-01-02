using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private MovementScript player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("isWalking", player.IsWalking());
    }
}
