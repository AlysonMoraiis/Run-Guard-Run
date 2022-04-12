using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScene;
    [SerializeField] private GameObject menuScene;
    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
        gameOverScene.SetActive(false);
        Time.timeScale = 1;
    }
}
