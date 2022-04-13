using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 700f;
    [SerializeField] private PlayerSwipeControl playerSwipeControl;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Jump();
        }

        Debug.Log(rb.velocity.y);
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
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
