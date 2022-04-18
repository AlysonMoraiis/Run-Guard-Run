using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerCollisions playerCollisions;

    private void OnEnable()
    {
        playerCollisions.OnDeath += PlayDeathAnimation;
    }

    private void OnDisable()
    {
        playerCollisions.OnDeath -= PlayDeathAnimation;
    }

    void Update()
    {
        if (rb.velocity.y == 0)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }

        else if (rb.velocity.y > 0)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", true);
            animator.SetBool("Fall", false);
        }

        else if (rb.velocity.y < 0)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
    }

    void PlayDeathAnimation()
    {
        animator.SetTrigger("Death");
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
}
