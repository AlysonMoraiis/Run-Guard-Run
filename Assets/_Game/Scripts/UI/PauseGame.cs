using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public void PauseAndUnapause()
    {
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
        SceneManager.LoadScene("Game");
    }
}
