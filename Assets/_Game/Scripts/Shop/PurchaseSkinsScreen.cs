using UnityEngine;
using UnityEngine.UI;
using System;

public class PurchaseSkinsScreen : MonoBehaviour
{
    public Skins _skins;
    [SerializeField] private GameData _gameData;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private SkinSelect _skinSelect;
    [SerializeField] private Text _skinName;
    [SerializeField] private Text _skinPrice;
    [SerializeField] private ScaleWindow _scaleWindow;
    [SerializeField] private Color _appleColor;
    [SerializeField] private Color _pineappleColor;

    public event Action OnPurchase;

    public void UpdateSkinsInfo(Skins skins)
    {
        _skins = skins;
        _skinName.text = skins.SkinName;
        if (_skins.ItsApple)
        {
            _skinPrice.color = _appleColor;
            _skinPrice.text = "FOR " + skins.SkinPrice.ToString() + " APPLES?";
        }
        else if (_skins.ItsPineapple)
        {
            _skinPrice.color = _pineappleColor;
            _skinPrice.text = "FOR " + skins.SkinPrice.ToString() + " PINEAPPLES?";
        }
    }

    public void HandlePurchaseButton()
    {
        if (_skins.ItsApple)
        {
            if (_gameData.Apple > _skins.SkinPrice)
            {
                _gameData.Apple -= _skins.SkinPrice;
                _skins.HasPurchased = true;
                _skinSelect.SetPlayerSelected(_skins.SkinIndex);
                _coinManager.TextUpdate();
                _scaleWindow.CloseWindowCall();
                OnPurchase?.Invoke();
            }
            else
            {
                Debug.Log("Buy more apples Popup");
            }
        }
        else
        {
            if (_gameData.Pineapple > _skins.SkinPrice)
            {
                _gameData.Pineapple -= _skins.SkinPrice;
                _skins.HasPurchased = true;
                _skinSelect.SetPlayerSelected(_skins.SkinIndex);
                _coinManager.TextUpdate();
                _scaleWindow.CloseWindowCall();
                OnPurchase?.Invoke();
            }
            else
            {
                Debug.Log("Buy more pineapples Popup");
            }
        }
    }
}
