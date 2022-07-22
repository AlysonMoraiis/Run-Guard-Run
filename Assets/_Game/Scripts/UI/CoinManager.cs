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
        int tCoinText = (int)gameData.Coin;
        _menuCoinText.text = tCoinText.ToString();
    }

    public void UpdateInGameText()
    {
        _inGameCoins += 1;
        _inGameCoinText.text = _inGameCoins.ToString();
    }

    public void RewardedButtonIncrement()
    {
        gameData.Coin += _inGameCoins;
        _inGameCoins *= 2;
        _gameOverCoinText.text = _inGameCoins.ToString();
    }

    public void OnDeathUpdate()
    {
        gameData.Coin += _inGameCoins;
        _gameOverCoinText.text = _inGameCoins.ToString();
    }


    public object SaveState()
    {
        Debug.Log("save coin " + gameData.Coin);
        return new SaveData()
        {
            coin = this.gameData.Coin
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        gameData.Coin = saveData.coin;
        Debug.Log("load coin" + gameData.Coin);
    }

    [Serializable]
    private struct SaveData
    {
        public float coin;
    }
}
