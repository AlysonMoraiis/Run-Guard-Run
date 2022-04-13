using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    void Update()
    {
        if(rb.velocity.y == 0)
        {
            animator.SetBool("Walk", true);
        }

        else
        {
            animator.SetBool("Jump", true);
        }
    }
}
