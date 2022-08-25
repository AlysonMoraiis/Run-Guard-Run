using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private AudioClip _uiClickClip;

    public void PauseAndUnapause()
    {
        SoundManager.Instance.PlaySound(_uiClickClip);
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }


    public void BackToMenu()
    {
        SoundManager.Instance.PlaySound(_uiClickClip);
        SceneManager.LoadScene("Game");
    }
}
