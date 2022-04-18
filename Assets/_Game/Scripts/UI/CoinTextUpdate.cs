using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinTextUpdate : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private Text coinText;

    void Start()
    {
        int tCoinText = (int)gameData.Coin;
        coinText.text = tCoinText.ToString();
    }
}
