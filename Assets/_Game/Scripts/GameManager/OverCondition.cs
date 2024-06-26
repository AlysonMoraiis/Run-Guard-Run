using UnityEngine;
using System.Collections;

public class OverCondition : MonoBehaviour
{
    [SerializeField] private PlayerCollisions playerCollisions;
    [SerializeField] private ScaleWindow scaleWindow;

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
        //SaveLoadSystem.Instance.Save();
        StartCoroutine(WaitATime());
    }

    IEnumerator WaitATime()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.6f);
        scaleWindow.OpenWindow();
    }
}
