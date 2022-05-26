using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CoinManager : MonoBehaviour, ISaveable
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Text coinText;

    void Start()
    {
        int tCoinText = (int)gameData.Coin;
        coinText.text = tCoinText.ToString();
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
