using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScene;
    [SerializeField] private GameObject menuScene;
    [SerializeField] private CoinManager _coinManager;

    [SerializeField] private GameObject _placeholderAdPopUp;
    [SerializeField] private AudioClip _uiClickClip;

    public void RestartLevel()
    {
        SoundManager.Instance.PlaySound(_uiClickClip);
        SaveLoadSystem.Instance.Save();
        SceneManager.LoadScene("Game");
        gameOverScene.SetActive(false);
        Time.timeScale = 1;
    }

    public void RewardedButton()
    {
        SoundManager.Instance.PlaySound(_uiClickClip);
        _coinManager.RewardedButtonIncrement();
        _placeholderAdPopUp.SetActive(true);
    }
}
