using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverCondition : MonoBehaviour
{
    [SerializeField] private PlayerCollisions playerCollisions;
    [SerializeField] private ScaleWindow scaleWindow;
    [SerializeField] private Button _homeButton;

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
        //SaveLoadSystem.Instance.Save();
        StartCoroutine(WaitATime());
    }

    IEnumerator WaitATime()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.6f);
        Debug.Log("passou");
        scaleWindow.OpenWindow();
    }
}
