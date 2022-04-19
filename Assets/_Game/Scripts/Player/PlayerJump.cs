using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 700f;
    [SerializeField] private PlayerSwipeControl playerSwipeControl;
    [SerializeField] private AudioClip JumpClip;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Jump();
        }
    }

    private void OnEnable()
    {
        playerSwipeControl.OnSwipeUp += Jump;
    }

    private void OnDisable()
    {
        playerSwipeControl.OnSwipeUp -= Jump;
    }

    void Jump()
    {
        if (rb.velocity.y == 0 && GameManager.Instance.GameIsRunning())
        {
            //rb.AddForce(Vector2.up * jumpForce);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            SoundManager.Instance.PlaySound(JumpClip);
        }
    }
}
