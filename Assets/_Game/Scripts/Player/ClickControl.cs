using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClickControl : MonoBehaviour
{
    public event Action OnJump;
    public event Action OnAccelerateFall;

    [SerializeField] private GameData _gameData;

    private void Update()
    {
        if (Input.touchCount > 0 && _gameData.ControlType == false)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                OnAccelerateFall?.Invoke();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                OnJump?.Invoke();
            }
        }
    }
}
