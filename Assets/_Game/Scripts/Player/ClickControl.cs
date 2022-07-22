using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickControl : MonoBehaviour
{
    public event Action OnJump;
    public event Action OnAccelerateFall;

    [SerializeField] private GameData _gameData;

    public void HandleJumpButton()
    {
        if (_gameData.ControlType == false)
        {
            OnJump?.Invoke();
        }
    }

    public void HandleAccelerateFallButton()
    {
        if (_gameData.ControlType == false)
        {
            OnAccelerateFall?.Invoke();
        }
    }
}
