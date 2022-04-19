using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip CollectSoundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameData.Coin += 1;
            Debug.Log("Coletou Moeda");
            animator.SetTrigger("Destroy");
            SoundManager.Instance.PlaySound(CollectSoundEffect);
        }
    }

    private void DestroyGameObjectOnAnimation()
    {
        Destroy(gameObject);
    }
}
