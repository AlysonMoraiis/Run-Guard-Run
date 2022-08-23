using UnityEngine;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public event Action OnDeath;
    public event Action OnCoinTrigger;
    [HideInInspector] public bool _playerIsAlive = true;
    [SerializeField] private AudioClip _deathClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnDeath?.Invoke();
            _playerIsAlive = false;
            Debug.Log("Morreu");
            SoundManager.Instance.PlaySound(_deathClip);
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
