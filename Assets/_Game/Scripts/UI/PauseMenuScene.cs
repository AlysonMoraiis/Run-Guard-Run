using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScene : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

    public void SwipeControlChoice()
    {
        _gameData.ControlType = true;
    }

    public void ClickControlChoice()
    {
        _gameData.ControlType = false;
    }
}
