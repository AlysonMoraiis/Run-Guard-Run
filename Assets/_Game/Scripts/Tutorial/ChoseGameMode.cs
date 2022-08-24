using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseGameMode : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private AudioSource _effectsSource;
    [SerializeField] private AudioClip _uiClickClip;
    public void SwipeControlMode()
    {
        _gameData.ControlType = true;
        NextScene();
    }

    public void TouchControlMode()
    {
        _gameData.ControlType = false;
        NextScene();
    }

    private void NextScene()
    {
        _effectsSource.PlayOneShot(_uiClickClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
