using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float dirX; 
    float MoveSpeed = 2f;

    void Update()
    {
        dirX = Input.acceleration.x * MoveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(dirX, 0f);
    }
}
