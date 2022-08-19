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

    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(HandleJumpButton);
    }

    public void HandleJumpButton()
    {
        OnJump?.Invoke();
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
