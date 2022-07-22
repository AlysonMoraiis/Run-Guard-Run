using UnityEngine;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public event Action OnDeath;
    public event Action OnCoinTrigger;
    [HideInInspector] public bool playerIsAlive = true;
    [SerializeField] private AudioClip DeathClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnDeath?.Invoke();
            playerIsAlive = false;
            Debug.Log("Morreu");
            SoundManager.Instance.PlaySound(DeathClip);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            OnCoinTrigger?.Invoke();
        }
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
