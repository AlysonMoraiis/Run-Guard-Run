using UnityEngine;

public class AccelerateFall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float accelerateForce = 400f;
    [SerializeField] private PlayerSwipeControl playerSwipeControl;
    [SerializeField] private AudioClip FallClip;

    private void OnEnable()
    {
        playerSwipeControl.OnSwipeDown += Accelerate;
    }

    private void OnDisable()
    {
        playerSwipeControl.OnSwipeDown -= Accelerate;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Accelerate();
        }
    }

    private void Accelerate()
    {
        if (rb.velocity.y != 0 && GameManager.Instance.GameIsRunning())
        {
            rb.AddForce(Vector2.down * accelerateForce);
            SoundManager.Instance.PlaySound(FallClip);
        }
    }
}
