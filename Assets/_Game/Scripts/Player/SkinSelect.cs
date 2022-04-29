using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private RuntimeAnimatorController[] playerController;
    [SerializeField] private Sprite[] playerRenderer;

    public void SetPlayerSelected(int index)
    {
        spriteRenderer.sprite = playerRenderer[index];
        animator.runtimeAnimatorController = playerController[index];
    }
}
