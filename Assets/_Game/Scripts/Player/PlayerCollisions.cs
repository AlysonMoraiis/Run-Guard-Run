using UnityEngine;
using System;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    public event Action OnDeath;
    public bool playerIsAlive = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            OnDeath?.Invoke();
            playerIsAlive = false;
            Debug.Log("Morreu");
        }

        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameData.Score += 100;
            Debug.Log("Moeda");
        }
    }
}
