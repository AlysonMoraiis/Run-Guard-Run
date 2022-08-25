using UnityEngine;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public event Action OnDeath;
    public event Action OnAppleTrigger;
    public event Action OnPineappleTrigger;
    [HideInInspector] public bool _playerIsAlive = true;
    [SerializeField] private AudioClip _deathClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnDeath?.Invoke();
            _playerIsAlive = false;
            SoundManager.Instance.PlaySound(_deathClip);
        }

        if (collision.gameObject.CompareTag("Apple"))
        {
            OnAppleTrigger?.Invoke();
        }
        
        if(collision.gameObject.CompareTag("Pineapple"))
        {
            OnPineappleTrigger?.Invoke();
        }
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
