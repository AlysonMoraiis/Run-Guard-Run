using UnityEngine;

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
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
