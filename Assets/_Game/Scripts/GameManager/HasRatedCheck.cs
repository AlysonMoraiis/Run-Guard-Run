using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasRatedCheck : MonoBehaviour
{
    [SerializeField] private RatedData _ratedData;
    [SerializeField] private ScaleWindow _rateScreen;

    void Start()
    {
        RateCheck();
    }

    private void RateCheck()
    {
        if (_ratedData.HasRated)
        {
            Destroy(this);
            return;
        }
        _ratedData.RestartCount++;
        if (_ratedData.RestartCount >= 8)
        {
            _ratedData.RestartCount = 0;
            ShowRateScreen();
        }
    }
    
    private void ShowRateScreen()
    {
        _rateScreen.OpenWindow();
        Time.timeScale = 0;
    }

    public void HandleRateButton()
    {
        _ratedData.HasRated = true;
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.kiloo.subwaysurf&hl=pt_BR&gl=US");
        _rateScreen.CloseWindowCall();
    }
}
