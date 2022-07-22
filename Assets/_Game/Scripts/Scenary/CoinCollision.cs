using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip CollectSoundEffect;

    public event Action OnCoinTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Moeda Coletada");
            animator.SetTrigger("Destroy");
            PlaySound();
        }
    }

    private void PlaySound()
    {
        SoundManager.Instance.PlaySound(CollectSoundEffect);
        SoundManager.Instance.IncrementPitch();
    }

    private void DestroyGameObjectOnAnimation()
    {
        Destroy(gameObject);
    }
}
