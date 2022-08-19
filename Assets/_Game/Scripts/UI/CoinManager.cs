using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CoinManager : MonoBehaviour, ISaveable
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Text _menuCoinText;
    [SerializeField] private Text _inGameCoinText;
    [SerializeField] private Text _gameOverCoinText;
    [SerializeField] private PlayerCollisions _playerCollisions;

    private int tCoinText;
    private int _inGameCoins;

    private void OnEnable()
    {
        _playerCollisions.OnCoinTrigger += UpdateInGameText;
        _playerCollisions.OnDeath += OnDeathUpdate;
    }

    private void OnDisable()
    {
        _playerCollisions.OnCoinTrigger -= UpdateInGameText;
        _playerCollisions.OnDeath -= OnDeathUpdate;
    }

    void Start()
    {
        tCoinText = (int)gameData.Apple;
        TextUpdate();
    }

    public void UpdateInGameText()
    {
        _inGameCoins += 1;
        TextUpdate();
    }

    public void RewardedButtonIncrement()
    {
        gameData.Apple += _inGameCoins;
        _inGameCoins *= 2;
        TextUpdate();
    }

    public void OnDeathUpdate()
    {
        gameData.Apple += _inGameCoins;
        TextUpdate();
    }

    public void TextUpdate()
    {
        tCoinText = (int)gameData.Apple;
        _gameOverCoinText.text = _inGameCoins.ToString();
        _inGameCoinText.text = _inGameCoins.ToString();
        _menuCoinText.text = tCoinText.ToString();
        Debug.Log("Coin value update");
    }


    public object SaveState()
    {
        Debug.Log("save coin " + gameData.Apple);
        return new SaveData()
        {
            coin = this.gameData.Apple
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        gameData.Apple = saveData.coin;
        Debug.Log("load coin" + gameData.Apple);
    }

    [Serializable]
    private struct SaveData
    {
        public int coin;
    }
}
