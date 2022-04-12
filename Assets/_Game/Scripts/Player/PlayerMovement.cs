using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int moveSpeed;



    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
