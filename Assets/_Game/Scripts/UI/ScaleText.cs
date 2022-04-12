using UnityEngine;
using DG.Tweening;

public class ScaleText : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector3 scaleTo;


    void Start()
    {
        rectTransform.DOScale(scaleTo, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
