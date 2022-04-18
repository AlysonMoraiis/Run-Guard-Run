using UnityEngine;
using System.Collections;

public class OverCondition : MonoBehaviour
{
    [SerializeField] private PlayerCollisions playerCollisions;
    [SerializeField] private GameObject gameOverMenu;

    private void OnEnable()
    {
        playerCollisions.OnDeath += GameOverMenu;
    }

    private void OnDisable()
    {
        playerCollisions.OnDeath -= GameOverMenu;
    }

    private void GameOverMenu()
    {
        Debug.Log("Abriu Menu");
        StartCoroutine(WaitATime());
    }

    IEnumerator WaitATime()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.6f);
        Debug.Log("passou");
        gameOverMenu.SetActive(true);
    }
}
