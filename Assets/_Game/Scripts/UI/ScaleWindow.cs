using UnityEngine;
using DG.Tweening;

public class ScaleWindow : MonoBehaviour
{
    [SerializeField] private Transform _windowTransform;
    [SerializeField] private Vector3 _initialScale = new Vector3(0,0,0);
    [SerializeField] private Vector3 _finalScale = new Vector3(1,1,1);
    [SerializeField] private float _scaleTime;
    [SerializeField] private GameObject _window;
    [SerializeField] private AudioClip _uiClickClip;

    public void OpenWindow()
    {
        _windowTransform.transform.localScale = _initialScale;
        SoundManager.Instance.PlaySound(_uiClickClip);
        _window.SetActive(true);
        _windowTransform.DOScale(_finalScale, _scaleTime).SetUpdate(true);
    }

    public void CloseWindowCall()
    {
        SoundManager.Instance.PlaySound(_uiClickClip);
        _windowTransform.DOScale(_initialScale, _scaleTime).OnComplete(CloseWindow).SetUpdate(true);
    }

    private void CloseWindow()
    {
        _window.SetActive(false);
    }

}
