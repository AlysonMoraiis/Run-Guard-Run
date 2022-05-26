using UnityEngine;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public event Action OnDeath;
    [HideInInspector] public bool playerIsAlive = true;
    [SerializeField] private AudioClip DeathClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            OnDeath?.Invoke();
            playerIsAlive = false;
            Debug.Log("Morreu");
            SoundManager.Instance.PlaySound(DeathClip); 
        }
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
