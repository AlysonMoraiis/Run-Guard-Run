using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CoinManager : MonoBehaviour, ISaveable
{

    [Header("Apple")]
    [SerializeField] private Text _menuAppleText;
    [SerializeField] private Text _inGameAppleText;
    private int tAppleText;
    private int _inGameApples;

    [Header("Pineapple")]
    [SerializeField] private Text _menuPineappleText;
    [SerializeField] private Text _inGamePineappleText;
    private int tPineappleText;
    private int _inGamePineapples;

    [Header("Others")]
    [SerializeField] private GameData gameData;
    [SerializeField] private PlayerCollisions _playerCollisions;

    private void OnEnable()
    {
        _playerCollisions.OnAppleTrigger += AppleIncrement;
        _playerCollisions.OnPineappleTrigger += PineappleIncrement;
        _playerCollisions.OnDeath += OnDeathUpdate;
    }

    private void OnDisable()
    {
        _playerCollisions.OnAppleTrigger -= AppleIncrement;
        _playerCollisions.OnPineappleTrigger -= PineappleIncrement;
        _playerCollisions.OnDeath -= OnDeathUpdate;
    }

    void Start()
    {
        tAppleText = (int)gameData.Apple;
        tPineappleText = (int)gameData.Pineapple;
        TextUpdate();
    }

    public void AppleIncrement()
    {
        _inGameApples += 1;
        TextUpdate();
    }

    public void PineappleIncrement()
    {
        _inGamePineapples += 1;
        TextUpdate();
    }

    public void RewardedButtonIncrement()
    {
        gameData.Apple += _inGameApples;
        gameData.Pineapple += _inGamePineapples;
        _inGameApples *= 2;
        _inGamePineapples *= 2;
        TextUpdate();
    }

    public void OnDeathUpdate()
    {
        gameData.Apple += _inGameApples;
        gameData.Pineapple += _inGamePineapples;
        TextUpdate();
    }

    public void TextUpdate()
    {
        tAppleText = (int)gameData.Apple;
        _inGameAppleText.text = _inGameApples.ToString();
        _menuAppleText.text = tAppleText.ToString();

        tPineappleText = (int)gameData.Pineapple;
        _inGamePineappleText.text = _inGamePineapples.ToString();
        _menuPineappleText.text = tPineappleText.ToString();
    }


    public object SaveState()
    {
        Debug.Log("Save apples: " + gameData.Apple);
        Debug.Log("Save pineapples: " + gameData.Pineapple);
        return new SaveData()
        {
            apple = this.gameData.Apple,
            pineapple = this.gameData.Pineapple
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        gameData.Apple = saveData.apple;
        gameData.Pineapple = saveData.pineapple;
        Debug.Log("Load apples: " + gameData.Apple);
        Debug.Log("Load pineapples: " + gameData.Pineapple);
    }

    [Serializable]
    private struct SaveData
    {
        public int apple;
        public int pineapple;
    }
}
