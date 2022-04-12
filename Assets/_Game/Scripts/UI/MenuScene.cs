using UnityEngine;
using DG.Tweening;

public class MenuScene : MonoBehaviour
{
    [SerializeField] GameObject menuScene;


    private void Start()
    {
        Time.timeScale = 0;
    }


    public void TapToPlay()
    {
        Time.timeScale = 1;
        menuScene.SetActive(false);
    }
}
