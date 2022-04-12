using UnityEngine;

public class AccelerateFall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float accelerateForce = 400f;
    [SerializeField] private PlayerSwipeControl playerSwipeControl;


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
        if (rb.velocity.y != 0)
        {
            rb.AddForce(Vector2.down * accelerateForce);
        }
    }
}
